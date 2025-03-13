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

        public Dictionary<DateTime, List<Screening>> ScreeningsByWeek { get; set; }

        public void OnGet()
        {
            var currentDate = DateTime.Now;

            var screenings = _dbContext.Screenings
                .Include(s => s.Film)
                .Where(s => s.Time >= currentDate)
                .OrderBy(s => s.Time)
                .ToList();

            ScreeningsByWeek = screenings
                .GroupBy(s => StartOfWeek(s.Time))
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        private DateTime StartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-diff).Date;
        }
    }
}