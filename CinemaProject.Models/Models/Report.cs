using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public DateTime GeneratedOn { get; set; } = DateTime.Now;

        public int TotalBookings { get; set; }
        public int TotalTicketsSold { get; set; }
        public double TotalRevenue { get; set; }
    }
}
