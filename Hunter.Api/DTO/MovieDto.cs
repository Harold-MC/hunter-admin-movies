using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Api.DTO
{
    public class MovieDto : Models.Movie
    {
        public string Name { get; set; }
    }
}
