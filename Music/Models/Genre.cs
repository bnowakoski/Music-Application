using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
   
    public class Genre
    {
        public int GenreID { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "Can't be longer than 20 characters")]

        public string Name { get; set; }

        public List<Album> Albums { get; set; }
    }

  
}