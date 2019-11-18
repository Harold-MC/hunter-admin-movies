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
    public class MovieController : Controller
    {
        ApiRequest client = new ApiRequest();

        // GET: Movie
        public async Task<ActionResult> Index()
        {
            var movieList = await client.Get<MovieResponse>("movies");
            var genreList = await client.Get<GenreDto>("genres");
            var model = new MovieGenreDto() { Genres = genreList.Body, MovieDto = movieList.Body };
            return View(model);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,GenreId,ReleaseDate,Photo")] Movie movie)
        {
           

            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            
            return View();
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,GenreId,ReleaseDate,Photo")] Movie movie)
        {
           
            return View(movie);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            
            return View();
        }
    }
}
