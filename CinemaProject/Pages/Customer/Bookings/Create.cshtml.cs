using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Customer.Bookings
{

    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Booking Booking { get; set; }
        public Film Film { get; set; }
        public Screening Screening { get; set; }
        public List<TicketType> TicketTypeList = new List<TicketType>();
        public List<int> ticketQuantities = new List<int>();

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            foreach (var ticketType in _unitOfWork.TicketTypeRepo.GetAll())
            {
                TicketTypeList.Add(ticketType);
                ticketQuantities.Add(0);
            }
        }


        public void OnGet(int id)
        {
            //Screening = _unitOfWork.ScreeningRepo.Get(id);
            //Film = _unitOfWork.FilmRepo.Get(Screening.FilmID);
            //Booking = new Booking();
            //Booking.Tickets = new List<Ticket>();
            Screening = _unitOfWork.ScreeningRepo.Get(id);

            if (Screening == null)
            {
                ModelState.AddModelError("", "Screening not found.");
                RedirectToPage("Index"); // Redirect to prevent errors
                return;
            }

            Film = _unitOfWork.FilmRepo.Get(Screening.FilmID);

            if (Film == null)
            {
                ModelState.AddModelError("", "Film not found.");
                RedirectToPage("Index");
                return;
            }
            
            Booking = new Booking { Tickets = new List<Ticket>(), TotalPrice = 0 };
        }

        public IActionResult OnPost(int screeningId)
        {
            if (ModelState.IsValid)
            {
                int y = 0;
                int? ScreenCap = _unitOfWork.CapacityRepo.Get(Screening.ScreenID).Capacity;

                int existingBookings = _unitOfWork.TicketRepo.GetAll()
                .Count(t => t.ScreeningId == Screening.Id);

                int newTicketsCount = ticketQuantities.Sum();

                if (y == 0)
                {
                    return RedirectToPage("Index");
                }

                if (existingBookings + newTicketsCount > ScreenCap)
                {
                    ModelState.AddModelError("", "Not enough seats available for this screening.");
                    return Page();
                }
                for (int i = 0; i < TicketTypeList.Count; i++)
                {

                    for (int x = 0; x < ticketQuantities[i]; x++)
                    {
                        y++;

                        Ticket tic = new Ticket
                        {
                            TicketTypeId = TicketTypeList[i].Id,
                            TicketType = TicketTypeList[i],
                            ScreeningId = Screening.Id,
                            Screening = Screening,
                            BookingId = Booking.Id,
                            Booking = Booking
                        };

                        _unitOfWork.TicketRepo.Add(tic);
                        Booking.Tickets.Add(tic);
                    }

                }

                _unitOfWork.BookingRepo.Add(Booking);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }

}
