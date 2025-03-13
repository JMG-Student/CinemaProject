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
		public Boolean isTickets = false;

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
			Booking = new Booking();
			Booking.Tickets = new List<Ticket>();
		}

		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				for (int i = 0; i < TicketTypeList.Count; i++)
				{

					for (int x = 0; x < ticketQuantities[i]; x++)
					{
						isTickets = true;

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
				if (isTickets == false) 
				{
					return RedirectToPage("Index");
				}

				_unitOfWork.BookingRepo.Add(Booking);
				_unitOfWork.Save();
			}
			return RedirectToPage("Index");
		}
	}
}
