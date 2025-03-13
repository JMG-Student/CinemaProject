using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models.Models
{
	public class TicketType
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public double Price { get; set; }



	}
}
