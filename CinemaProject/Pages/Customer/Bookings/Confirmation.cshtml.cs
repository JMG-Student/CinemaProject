using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.Models.Models;

namespace CinemaProject.Pages.Customer.Bookings
{
    public class ConfirmationModel : PageModel
    {
			private readonly IUnitOfWork _unitOfWork;

			public ConfirmationModel(IUnitOfWork unitOfWork)
			{
				_unitOfWork = unitOfWork;
			}

			public Booking booking { get; set; }

			public void OnGet(int id)
			{

				booking = _unitOfWork.BookingRepo.Get(id);
				
				foreach (var ticket in _unitOfWork.TicketRepo.GetAll())
				{
					if (ticket.BookingId == booking.Id)
					{
						ticket.TicketType = _unitOfWork.TicketTypeRepo.Get(ticket.TicketTypeId);
						ticket.Screening = _unitOfWork.ScreeningRepo.Get(ticket.ScreeningId);
						booking.Tickets.Add(ticket);
					}
				
				}

		}

	}
}
