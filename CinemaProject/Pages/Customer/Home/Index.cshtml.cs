using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Film> listOfFilms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsNextWeek { get; set; }

        public void OnGet()
        {
            var currentDate = DateTime.Now;
            var weekStart = IsNextWeek ? currentDate.AddDays(7 - (int)currentDate.DayOfWeek) : currentDate.AddDays(-(int)currentDate.DayOfWeek);
            var weekEnd = weekStart.AddDays(7);

            var allFilms = _unitOfWork.FilmRepo.GetAll()
                .Include(f => f.Screenings)
                .Include(f => f.Genre)
                .ToList();

            if (!string.IsNullOrEmpty(SearchString))
            {
                allFilms = allFilms
                    .Where(p => p.Title.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            listOfFilms = allFilms
                .Where(f => f.Screenings.Any(s => s.Time >= weekStart && s.Time < weekEnd))
                .ToList();

            ViewData["IsNextWeek"] = IsNextWeek;
        }
    }
}