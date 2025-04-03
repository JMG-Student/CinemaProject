using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SelectPdf; // Using SelectPdf for the PDF export

namespace CinemaProject.Pages.Admin.Reports
{
    public class ReportModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        public Report CurrentReport { get; set; } = new();
        public List<Report> PastReports { get; set; } = new();
        public Dictionary<string, (int TicketsSold, decimal Revenue)> FilmStats { get; set; } = new();

        public ReportModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            // Only set default values if none were supplied in the query string
            if (StartDate == default)
                StartDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1); // Monday

            if (EndDate == default)
                EndDate = DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek).Date.AddDays(1).AddTicks(-1); // Sunday 23:59:59

            LoadData();
        }

        public IActionResult OnPostGenerate()
        {
            if (!ModelState.IsValid)
                return Page();

            GenerateAndSaveReport();

            // Pass selected dates back in query to preserve them
            return RedirectToPage(new
            {
                StartDate = StartDate.ToString("yyyy-MM-dd"),
                EndDate = EndDate.ToString("yyyy-MM-dd")
            });
        }

        private void LoadData()
        {
            CurrentReport = GenerateReport(StartDate, EndDate);

            PastReports = _unitOfWork.ReportRepo.GetAll()
                .OrderByDescending(r => r.GeneratedOn)
                .ToList();
        }

        private void GenerateAndSaveReport()
        {
            string reportTitle = $"{StartDate:ddd dd/MM/yyyy} - {EndDate:ddd dd/MM/yyyy}";

            var existing = _unitOfWork.ReportRepo.GetAll()
                .FirstOrDefault(r => r.ReportTitle == reportTitle);

            if (existing != null)
                return;

            var report = GenerateReport(StartDate, EndDate);
            _unitOfWork.ReportRepo.Add(report);
            _unitOfWork.Save();
        }

        private Report GenerateReport(DateTime start, DateTime end)
        {
            var bookings = _unitOfWork.BookingRepo.GetAll()
                .Where(b => b.BookingDate >= start && b.BookingDate <= end)
                .ToList();

            var bookingIds = bookings.Select(b => b.Id).ToHashSet();

            var tickets = _unitOfWork.TicketRepo.GetAll()
                .Where(t => bookingIds.Contains(t.BookingId))
                .ToList();

            var ticketTypes = _unitOfWork.TicketTypeRepo.GetAll().ToDictionary(tt => tt.Id);

            foreach (var ticket in tickets)
            {
                if (ticketTypes.TryGetValue(ticket.TicketTypeId, out var type))
                {
                    ticket.TicketType = type;
                }
            }

            FilmStats = tickets
                .Where(t => t.Screening?.Film != null)
                .GroupBy(t => t.Screening.Film.Title)
                .ToDictionary(
                    g => g.Key,
                    g => (
                        TicketsSold: g.Count(),
                        Revenue: (decimal)g.Sum(t => t.TicketType?.Price ?? 0)
                    )
                );

            return new Report
            {
                ReportTitle = $"{start:ddd dd/MM/yyyy} - {end:ddd dd/MM/yyyy}",
                GeneratedOn = DateTime.Now,
                TotalBookings = bookings.Count,
                TotalTicketsSold = tickets.Count,
                TotalRevenue = tickets.Sum(t => t.TicketType?.Price ?? 0)
            };
        }

        public IActionResult OnPostDownloadPdf()
        {
            var html = $@"
                <h2>{CurrentReport.ReportTitle}</h2>
                <p><strong>Generated On:</strong> {CurrentReport.GeneratedOn}</p>
                <p><strong>Total Bookings:</strong> {CurrentReport.TotalBookings}</p>
                <p><strong>Total Tickets Sold:</strong> {CurrentReport.TotalTicketsSold}</p>
                <p><strong>Total Revenue:</strong> {CurrentReport.TotalRevenue:C}</p>
                <hr/>
                <h4>Tickets Sold Per Film</h4>
                <ul>
                    {string.Join("", FilmStats.Select(f => $"<li>{f.Key}: {f.Value.TicketsSold} tickets — {f.Value.Revenue:C}</li>"))}
                </ul>";

            var converter = new HtmlToPdf();
            var doc = converter.ConvertHtmlString(html);
            var pdf = doc.Save();
            doc.Close();

            return File(pdf, "application/pdf", "WeeklyReport.pdf");
        }
    }
}
