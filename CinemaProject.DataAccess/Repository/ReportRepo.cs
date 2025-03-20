using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;

namespace CinemaProject.DataAccess.Repository
{
    public class ReportRepo : Repository<Report>, IReportRepo
    {
        private readonly AppDBContext _dbContext;

        public ReportRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Report GenerateReport()
        {
            var bookings = _dbContext.Bookings.ToList();
            int totalTickets = bookings.Sum(b => b.Tickets.Count);
            double totalRevenue = bookings.Sum(b => b.TotalPrice);

            return new Report
            {
                TotalBookings = bookings.Count,
                TotalTicketsSold = totalTickets,
                TotalRevenue = totalRevenue
            };
        }
    }
}

