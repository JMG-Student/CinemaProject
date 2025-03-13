﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }

		public double TotalPrice { get; set; }

		public List<Ticket>? Tickets { get; set; }
    }
}
