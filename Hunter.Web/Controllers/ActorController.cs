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
    public class ActorController : Controller
    {
        ApiRequest client = new ApiRequest();

        // GET: Actor
        public async Task<ActionResult> Index()
        {
            var movieList = await client.Get<ActorResponseDto>("actors");
            return View(movieList.Body);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Birthday,Photo,Sex")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                bool inserted = await client.Post("actors", new List<string>() { actor.Name, actor.Birthday.ToString(), $"{actor.Sex}", actor.Photo });
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var list = await client.Get<Actor>($"actors/{id}");
            return View(list);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Sex,Birthday,Photo")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                var dictionary = new Dictionary<string, string>();
                if (actor.Name != "" || actor.Name != null)
                {
                    dictionary.Add("Name", actor.Name);
                }
                if (actor.Birthday != null)
                {
                    dictionary.Add("Birthday", actor.Birthday.ToString());
                }
                if (actor.Photo != "" || actor.Photo != null)
                {
                    dictionary.Add("Photo", actor.Photo);
                }

                var list = await client.Put("actors", actor.Id, dictionary);
            }
            return RedirectToAction("Index");
        }

        // GET: Actor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            await client.Delete("actors", id.Value);
            return RedirectToAction("Index");
        }

    }
}
