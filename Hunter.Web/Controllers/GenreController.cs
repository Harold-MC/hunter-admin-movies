using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Hunter.Web.Api;
using Hunter.Web.Models;
using Hunter.Web.Models.DTO;

namespace Hunter.Web.Controllers
{
    public class GenreController : Controller
    {
        ApiRequest client = new ApiRequest();

        // GET: Genre
        public async Task<ActionResult> Index()
        {
            var list = await client.Get<ResponseDto<Genre>>("genres");
            return View(list.Body);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                bool inserted = await client.Post("genres", new List<string>() { genre.Name });
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genre/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var list = await client.Get<Genre>($"genres/{id}");
            return View(list);
        }

        // POST: Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                var list = await client.Put("genres", genre.Id, new Dictionary<string, string>() { { "name", genre.Name } });
            }
            return RedirectToAction("Index");
        }

        // GET: Genre/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            await client.Delete("genres", id.Value);
            return RedirectToAction("Index");
        }

        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await client.Delete("genres", id);
            return RedirectToAction("Index");
        }
    }
}
