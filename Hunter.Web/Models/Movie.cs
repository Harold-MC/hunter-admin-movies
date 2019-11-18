using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hunter.Web.Models
{
    public class MovieResponse
    {
        public List<MovieDto> Body { get; set; }
        public int StatusCode { get; set; }
    }

    public class MovieDto : Movie
    {
        public string Name { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Photo { get; set; }
    }
}