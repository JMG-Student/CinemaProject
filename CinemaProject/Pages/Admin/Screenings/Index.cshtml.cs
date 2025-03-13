using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages.Admin.Screenings
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public IEnumerable<Screening> Screenings;

        public IndexModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public void OnGet()
        //{
        //    Screenings = _dbContext.Screenings
        //        .Include(s => s.Film)
        //        .ToList();
        //}

        public Dictionary<DateTime, List<Screening>> ScreeningsByWeek { get; set; }

        public void OnGet()
        {
            var currentDate = DateTime.Now;

            // Fetch screenings that are in the future and include related Film data
            var screenings = _dbContext.Screenings
                .Include(s => s.Film)
                .Where(s => s.Time >= currentDate) // Filter out past screenings
                .OrderBy(s => s.Time) // Sort by date and time
                .ToList();

            // Group screenings by week starting from Monday
            ScreeningsByWeek = screenings
                .GroupBy(s => StartOfWeek(s.Time))
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Helper method to get the start of the week (Monday)
        private DateTime StartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-diff).Date;
        }
    }
}