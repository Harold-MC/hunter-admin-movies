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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var filter = new Dictionary<string, string>() { {"id", id.ToString()} };
            return Ok(ApiResponse.Send(Repo.Delete(filter)));
        }

        [HttpPost]
        public ActionResult Insert([FromBody]List<string> values)
        {
            return Ok(ApiResponse.Send(Repo.Insert(values)));
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]Dictionary<string, string> fieldUpdates, int id)
        {
            return Ok(ApiResponse.Send(Repo.Update(fieldUpdates, new Dictionary<string, string>() { { "Id", $"{id}" } })));
        }
    }
}
