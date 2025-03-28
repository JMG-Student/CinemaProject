using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Reports
{
    public class WeeklyModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1); // Auto-set to Monday

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek); // Auto-set to Sunday

        public Report CurrentReport { get; set; }
        public List<Report> PastReports { get; set; } = new();

        public WeeklyModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            LoadData();
        }

        public IActionResult OnPostGenerate()
        {
            if (!ModelState.IsValid)
                return Page();

            GenerateAndSaveReport();
            return RedirectToPage();
        }

        private void LoadData()
        {
            // Get current week's data (not saved yet)
            CurrentReport = GenerateReport(StartDate, EndDate);

            // Get past saved reports
            PastReports = _unitOfWork.ReportRepo.GetAll()
                .OrderByDescending(r => r.GeneratedOn)
                .ToList();
        }

        private void GenerateAndSaveReport()
        {
            var report = GenerateReport(StartDate, EndDate);
            _unitOfWork.ReportRepo.Add(report);
            _unitOfWork.Save();
        }

        private Report GenerateReport(DateTime start, DateTime end)
        {
            // Get ALL bookings/tickets first, then filter in memory
            var allBookings = _unitOfWork.BookingRepo.GetAll().ToList();
            var allTickets = _unitOfWork.TicketRepo.GetAll().ToList();

            // Filter locally (works but less efficient for large datasets)
            var bookings = allBookings
                .Where(b => b.BookingDate >= start && b.BookingDate <= end)
                .ToList();

            var tickets = allTickets
                .Where(t => t.Screening != null && t.Screening.Time >= start && t.Screening.Time <= end)
                .ToList();


            // Load ticket prices (if needed)
            foreach (var ticket in tickets)
            {
                ticket.TicketType = _unitOfWork.TicketTypeRepo.Get(ticket.TicketTypeId);
            }

            return new Report
            {
                ReportTitle = $"{start:ddd dd/MM/yyyy} - {end:ddd dd/MM/yyyy}",
                GeneratedOn = DateTime.Now,
                TotalBookings = bookings.Count,
                TotalTicketsSold = tickets.Count,
                TotalRevenue = tickets.Sum(t => t.TicketType?.Price ?? 0)   
            };
        }

    }
}
