using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Genres
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Genre Genre { get; set; }
        public void OnGet(int id)
        {
            Genre = _unitOfWork.GenreRepo.Get(id);
        }

        public IActionResult OnPost(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GenreRepo.Update(genre);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}