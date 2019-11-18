using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Api.DTO
{
    public class Movies_ActorDto
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public char Sex { get; set; }
        public string ActorPhoto { get; set; }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MoviePhoto { get; set; }
    }
}
