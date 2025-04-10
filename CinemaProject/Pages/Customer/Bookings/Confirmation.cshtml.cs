using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;
using CinemaProject.Pages.PageViewModels;
using System.Drawing;


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
		public ConfirmTicket[] tickets = new ConfirmTicket[] { };
        public void OnGet(int id)
		{

			booking = _unitOfWork.BookingRepo.Get(id);
			ConfirmTicket confirmTicket;

			foreach (var ticket in _unitOfWork.TicketRepo.GetAll())
			{
				if (ticket.BookingId == booking.Id)
				{
					ticket.TicketType = _unitOfWork.TicketTypeRepo.Get(ticket.TicketTypeId);
					ticket.Screening = _unitOfWork.ScreeningRepo.Get(ticket.ScreeningId);
					ticket.Screening.Film = _unitOfWork.FilmRepo.Get(ticket.Screening.FilmID);
						
				}
				
			}

			foreach (var type in _unitOfWork.TicketTypeRepo.GetAll())
			{
				confirmTicket = new ConfirmTicket();
				confirmTicket.Count = _unitOfWork.TicketRepo.GetAll().Where(t => t.TicketType == type && t.BookingId == id).Count();
				confirmTicket.Type = type;
				confirmTicket.TotalPrice = type.Price * confirmTicket.Count;

                tickets.Append(confirmTicket);


            }

			QRCodeGenerator qrGenerator = new QRCodeGenerator();
			QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
			SvgQRCode qrCode = new SvgQRCode(qrCodeData);
			string qrCodeAsSvg = qrCode.GetGraphic(20);

        }

    }
}
