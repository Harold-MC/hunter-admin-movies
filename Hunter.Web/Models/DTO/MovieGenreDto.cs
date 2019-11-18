using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hunter.Web.Models.DTO
{
    public class MovieGenreDto
    {
        public List<Genre> Genres { get; set; }
        public List<MovieDto> MovieDto { get; set; }
    }
}