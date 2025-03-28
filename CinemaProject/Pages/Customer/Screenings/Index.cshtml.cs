using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Pages.Customer
{
    public class ScreeningsModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public ScreeningsModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty(SupportsGet = true)]
        public int? FilmId { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime WeekStart { get; set; }

        public DateTime WeekEnd => WeekStart.AddDays(6);

        public List<Screening> Screenings { get; set; }

        public void OnGet(string currentWeekStart = null)
        {
            if (string.IsNullOrEmpty(currentWeekStart))
            {
                WeekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            }
            else
            {
                WeekStart = DateTime.Parse(currentWeekStart);
            }
            LoadScreenings();
        }

        public IActionResult OnGetPreviousWeek(string currentWeekStart)
        {
            WeekStart = DateTime.Parse(currentWeekStart).AddDays(-7);
            LoadScreenings();
            return Page();
        }

        public IActionResult OnGetNextWeek(string currentWeekStart)
        {
            WeekStart = DateTime.Parse(currentWeekStart).AddDays(7);
            LoadScreenings();
            return Page();
        }

        private void LoadScreenings()
        {
            var query = _dbContext.Screenings
                .Include(s => s.Film)
                .Include(s => s.Screen)
                .Where(s => s.Time >= WeekStart && s.Time < WeekEnd.AddDays(1))
                .AsQueryable();

            if (FilmId.HasValue)
            {
                query = query.Where(s => s.FilmID == FilmId.Value);
            }

            Screenings = query.OrderBy(s => s.Time).ToList();
        }
    }
}