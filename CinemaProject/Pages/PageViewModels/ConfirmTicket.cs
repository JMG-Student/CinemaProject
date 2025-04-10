using CinemaProject.Models.Models;

namespace CinemaProject.Pages.PageViewModels
{
    public class ConfirmTicket
    {
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public TicketType Type { get; set; }
    }
}
