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
        public int ScreeningId { get; set; }

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
            Screening = _unitOfWork.ScreeningRepo.Get(id);
            Film = _unitOfWork.FilmRepo.Get(Screening.FilmID);
            Booking = new Booking() { TotalPrice = 0 };
            Booking.Tickets = new List<Ticket>();
            ScreeningId = id;

        }

        public IActionResult OnPost(Booking booking, List<int> ticketQuantities, int ScreeningId)
        {
            if (ModelState.IsValid)
            {
                int ticketsOnHold = 0;
                foreach (int quantie in ticketQuantities)
                {
                    ticketsOnHold += quantie;
                }
                if (ticketsOnHold <= 0)
                {
                    return RedirectToPage("Index");

                }
                //getting the screening capacity
                Screening screening = _unitOfWork.ScreeningRepo.Get(ScreeningId);
                Screen screen = _unitOfWork.ScreenRepo.Get(screening.ScreenID);
                Cap cap = _unitOfWork.CapacityRepo.Get(screen.CapId);

                _unitOfWork.BookingRepo.Add(booking);
                _unitOfWork.Save();
                int bookedTickets = _unitOfWork.TicketRepo.GetAll().Count(t => t.ScreeningId == ScreeningId);
                int availableSeats = (int)cap.Capacity - bookedTickets;

                if (ticketsOnHold > availableSeats)
                {
                    return RedirectToPage("/Customer/Home/Index");
                    //ModelState.AddModelError("", "Too many tickets selected. Not enough seats available.");
                    //return Page();
                }

                for (int i = 0; i < TicketTypeList.Count; i++)
                {

                    for (int x = 0; x < ticketQuantities[i]; x++)
                    {


                        Ticket tic = new Ticket
                        {
                            TicketTypeId = TicketTypeList[i].Id,
                            TicketType = TicketTypeList[i],
                            ScreeningId = ScreeningId,
                            BookingId = booking.Id,
                        };
                        booking.TotalPrice += TicketTypeList[i].Price;

                        _unitOfWork.TicketRepo.Add(tic);

                    }

                }
                _unitOfWork.BookingRepo.Update(booking);
                _unitOfWork.Save();

                return RedirectToPage("Confirmation", new { id = booking.Id });
            }
            else
            {
                //TO BE OR NOT TO BE FIXED BY AOIFE / REALLY JAMES
                //ModelState.AddModelError("", "To many Tickets");
                return RedirectToPage("/Customer/Home/Index");
            }

            
        }
    }
}


