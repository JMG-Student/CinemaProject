using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        
		public int TicketTypeId { get; set; }
		public TicketType TicketType { get; set; }

		public int ScreeningId { get; set; }
		public Screening Screening { get; set; }

        public int BookingId { get; set; }
        public Booking Booking { get; set; }


	}
}
