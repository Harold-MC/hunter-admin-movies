using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hunter.Api.Repositories.Base;
using Hunter.Api.Models;
using Hunter.Api.Helpers;

namespace Hunter.Api.HTTP.Controllers.Common
{
    [ApiController]
    public class WriteController<T> : ControllerBase
    {
        protected IBaseRepository<T> Repo { get; set; }
        public WriteController(IBaseRepository<T> _repo)
        {
            Repo = _repo;
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return Ok(ApiResponse.Send(Repo.Delete(null)));
        }

        [HttpPost]
        public ActionResult Insert()
        {
            return Ok(ApiResponse.Send(Repo.Insert(null)));
        }

        [HttpPut]
        public ActionResult Update()
        {
            return Ok(ApiResponse.Send(Repo.Update(null, null)));
        }
    }
}
