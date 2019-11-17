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
    public class GenresController : Common.WriteController<Genre>
    {
        public GenresController(IBaseRepository<Genre> _repo) : base(_repo){ }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ApiResponse.Send(Repo.Get()));
        }
    }
}