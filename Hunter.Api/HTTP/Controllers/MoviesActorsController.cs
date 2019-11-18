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
    public class MoviesActorsController : Common.WriteController<Movie>
    {
        public MoviesActorsController(IBaseRepository<Movie> _repo) : base(_repo) { }

        [HttpGet("{filter}")]
        public ActionResult Get(string filter)
        {
            var result = Repo.Get<DTO.Movies_ActorDto>(
                new List<string>() { 
                    "Movies.Id as MovieId", 
                    "Title", 
                    "GenreId", 
                    "ReleaseDate",
                    "Actors.Photo as ActorPhoto", 
                    "Movies.Photo as MoviePhoto", 
                    "Name", 
                    "Actors.Id as ActorId",
                    "Sex"
                },
                new Dictionary<string, string>() { 
                    { "Movies_Actors", "MovieId" }, 
                    { "Actors", "Id" } }
                );

            var filtered = result.Where(x => x.Name.Contains(filter) || x.Title.Contains(filter));
            return Ok(ApiResponse.Send(filtered));
        }
    }
}