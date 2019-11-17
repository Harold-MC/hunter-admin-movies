using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hunter.Api.Repositories.Base;
using Hunter.Api.Models;
using Hunter.Api.Helpers;

namespace Hunter.Api.HTTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Common.WriteController<Movie>
    {
        public MoviesController(IBaseRepository<Movie> _repo) : base(_repo) { }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ApiResponse.Send(Repo.Get<DTO.MovieDto>(
                new List<string>() { "Movies.Id", "Title", "GenreId", "ReleaseDate", "Photo", "Name" },
                new Dictionary<string, string>() { { "Genres", "Id" } }
                )));
        }
    }
}