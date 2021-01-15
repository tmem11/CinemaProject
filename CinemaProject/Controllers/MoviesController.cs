using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaProject.Models;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace CinemaProject.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
          

            
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie,HttpPostedFileBase imageUp)
        {
            if (ModelState.IsValid)
            {
                string imagePath = Path.Combine(Server.MapPath("~/uploads"), imageUp.FileName);
                imageUp.SaveAs(imagePath);
                movie.movieImage = imageUp.FileName;
                movie.porularity = 0;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie, HttpPostedFileBase imageUp)
        {
            if (ModelState.IsValid)
            {
                string imagePath = Path.Combine(Server.MapPath("~/uploads"), imageUp.FileName);
                imageUp.SaveAs(imagePath);
                movie.movieImage = imageUp.FileName;
                movie.porularity = 0;
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async void getdata()
        {
            WebClient client = new WebClient();
            string url = "https://api.themoviedb.org/3/movie/550?api_key=9cfa101b32f69a78e40944807f526384";
            var  allmovies = client.DownloadString("https://api.themoviedb.org/3/movie/550?api_key=9cfa101b32f69a78e40944807f526384");
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(allmovies);
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                Movie movie = new Movie();
                // Now parse with JSON.Net
            }


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
