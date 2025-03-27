using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Reports
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Report? ReportData { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            var bookings = _unitOfWork.BookingRepo.GetAll();
            var tickets = _unitOfWork.TicketRepo.GetAll();

            foreach (var ticket in tickets)
            {
                ticket.TicketType = _unitOfWork.TicketTypeRepo.Get(ticket.TicketTypeId);
            }

            ReportData = new Report
            {
                GeneratedOn = DateTime.Now,
                TotalBookings = bookings.Count(),
                TotalTicketsSold = tickets.Count(),
                TotalRevenue = tickets.Sum(t => t.TicketType?.Price ?? 0)
            };
        }
    }
}
