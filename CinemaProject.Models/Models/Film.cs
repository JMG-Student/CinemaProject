﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public string PosterLink { get; set; }

        public int GenreId { get; set; }
       
        public string TrailerLink { get; set; }
        public Genre? Genre { get; set; }

        [Required]
        public int Runtime { get; set; }

    }
}
