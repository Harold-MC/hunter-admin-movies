using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hunter.Web.Models.DTO
{
    public class ActorResponseDto
    {
        public List<Actor> Body { get; set; }
        public int StatusCode { get; set; }
    }
}