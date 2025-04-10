using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

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
        public int availableSeats;

        public bool NotEnoughSeats { get; set; } = false;


        public int ScreeningId { get; set; }

        //card deatials 
        [Required]
        public string CardHolderName { get; set; }
        [Required]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be 16 digits.")]
        public string CardNumber { get; set; }
        //CCV has to have a lengh of 3
        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "CCV must be exactly 3 digits.")]
        public string CCV { get; set; }

        [Required]
        public string ExpirationDate { get; set; }


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

            //getting the screening capacity
            Screening screening = _unitOfWork.ScreeningRepo.Get(ScreeningId);
            Screen screen = _unitOfWork.ScreenRepo.Get(screening.ScreenID);
            Cap cap = _unitOfWork.CapacityRepo.Get(screen.CapId);
            int bookedTickets = _unitOfWork.TicketRepo.GetAll().Count(t => t.ScreeningId == ScreeningId);
            availableSeats = (int)cap.Capacity - bookedTickets;

        }

        public IActionResult OnPost(Booking booking, List<int> ticketQuantities, int ScreeningId)
        {
            // 🔁 Recalculate available seats
            Screening screening = _unitOfWork.ScreeningRepo.Get(ScreeningId);
            Screen screen = _unitOfWork.ScreenRepo.Get(screening.ScreenID);
            Cap cap = _unitOfWork.CapacityRepo.Get(screen.CapId);
            int bookedTickets = _unitOfWork.TicketRepo.GetAll().Count(t => t.ScreeningId == ScreeningId);
            availableSeats = (int)cap.Capacity - bookedTickets;
            // Set up initial state
            booking.TotalPrice = 0;
            booking.Tickets = new List<Ticket>();

            // 🔑 Step 1: Save the booking FIRST to get the generated ID
            _unitOfWork.BookingRepo.Add(booking);
            _unitOfWork.Save(); // <-- make sure this is not missing or commented out!


            // ✅ Also reassign these for page redisplay
            Screening = screening;
            Film = _unitOfWork.FilmRepo.Get(Screening.FilmID);
            Booking = booking;
            this.ScreeningId = ScreeningId;
            this.ticketQuantities = ticketQuantities;

            if (ModelState.IsValid)
            {
                // Validate expiration
                if (!DateTime.TryParseExact(ExpirationDate, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiry))
                {
                    ModelState.AddModelError("ExpirationDate", "Invalid format. Use MM/YYYY.");
                }
                else if (expiry < DateTime.Now)
                {
                    ModelState.AddModelError("ExpirationDate", "Card has expired.");
                }

                int ticketsOnHold = ticketQuantities.Sum();

                if (ticketsOnHold <= 0)
                {
                    return RedirectToPage("Index");
                }

                if (ticketsOnHold > availableSeats)
                {
                    NotEnoughSeats = true;
                    return Page(); // shows modal
                }

                // Save tickets
                for (int i = 0; i < TicketTypeList.Count; i++)
                {
                    for (int j = 0; j < ticketQuantities[i]; j++)
                    {
                        Ticket ticket = new Ticket
                        {
                            TicketTypeId = TicketTypeList[i].Id,
                            ScreeningId = ScreeningId,
                            BookingId = booking.Id // ✅ now booking.Id is guaranteed to exist
                        };

                        booking.TotalPrice += TicketTypeList[i].Price;
                        _unitOfWork.TicketRepo.Add(ticket);
                    }
                }


                _unitOfWork.BookingRepo.Update(booking); // Update price
                _unitOfWork.Save();

                TempData["SuccessMessage"] = "Payment successful! Your booking is confirmed.";
                return RedirectToPage("Confirmation", new { id = booking.Id });
            }

            return RedirectToPage("/Customer/Home/Index");
        }

    }
}


