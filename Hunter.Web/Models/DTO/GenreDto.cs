using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hunter.Web.Models.DTO
{
    public class GenreDto
    {
        public List<Genre> Body { get; set; }
        public int StatusCode { get; set; }
    }
}