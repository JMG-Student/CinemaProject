using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CinemaProject.Pages.Admin.Screenings
{
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public CreateModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Screening Screening{ get; set; }

        public IEnumerable<SelectListItem> ScreenList { get; set; }
        public IEnumerable<SelectListItem> FilmList { get; set; }

        public void OnGet()
        {
            ScreenList = _dbContext.Screens.Select(i => new SelectListItem()
            {
                Text = ("Screen "+(i.Id.ToString())),
                Value = i.Id.ToString(),
            });

            FilmList = _dbContext.Films.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.Id.ToString(),
            });
        }

        public async Task<IActionResult> OnPost(Screening screening)
        {
            if (ModelState.IsValid)
            {
                var film = await _dbContext.Films.FindAsync(screening.FilmID);
                if (film == null)
                {
                    ModelState.AddModelError("Screening.FilmID", "Invalid film selected.");
                    return await ReloadDropdowns(screening);
                }

                var screeningEndTime = screening.Time.AddMinutes(film.Runtime);

                var overlappingScreenings = await _dbContext.Screenings
                    .Where(s => s.ScreenID == screening.ScreenID)
                    .Where(s => s.Time < screeningEndTime && s.Time.AddMinutes(s.Film.Runtime) > screening.Time)
                    .ToListAsync();

                if (overlappingScreenings.Any())
                {
                    ModelState.AddModelError("Screening.Time", "The screening overlaps with an existing screening in the same screen.");
                    return await ReloadDropdowns(screening);
                }

                await _dbContext.Screenings.AddAsync(screening);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return await ReloadDropdowns(screening);
        }

        private async Task<IActionResult> ReloadDropdowns(Screening screening)
        {
            ScreenList = await _dbContext.Screens.Select(i => new SelectListItem()
            {
                Text = "Screen " + i.Id.ToString(),
                Value = i.Id.ToString(),
                Selected = i.Id == screening.ScreenID
            }).ToListAsync();

            FilmList = await _dbContext.Films.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.Id.ToString(),
                Selected = i.Id == screening.FilmID
            }).ToListAsync();

            return Page();
        }
    }
}