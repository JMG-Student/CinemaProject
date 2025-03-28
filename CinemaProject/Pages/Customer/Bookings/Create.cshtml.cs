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
				int y = 0;
				_unitOfWork.BookingRepo.Add(booking);
				_unitOfWork.Save();
				for (int i = 0; i < TicketTypeList.Count; i++)
				{

                    for (int x = 0; x < ticketQuantities[i]; x++)
                    {
                        y++;

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
				
				if (y == 0) 
				{
					return RedirectToPage("Index");
				}
				//else if(y >= screen capactity){}

				_unitOfWork.BookingRepo.Update(booking);
				_unitOfWork.Save();
				
				return RedirectToPage("Confirmation", new {id = booking.Id});
			}
			return RedirectToPage("Index");
		}
	}
}
