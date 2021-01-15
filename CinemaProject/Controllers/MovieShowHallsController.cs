using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaProject.Models;

namespace CinemaProject.Controllers
{
    public class MovieShowHallsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MovieShowHalls
        public ActionResult Index()
        {
            

            var movieShowHalls = db.MovieShowHalls.Include(m => m.hall).Include(m => m.Movie);
            return View(movieShowHalls.ToList());
            //ViewBag.PriceHighLow = "price_lower";
          //  ViewBag.PriceLowHigh = "price_higher";
        }
        public ActionResult moviesonair(string orderBy)
        {
            ViewBag.category = new SelectList(db.Movies, "genere", "genere");
            var movies = from s in db.Movies
                      select s;
            switch (orderBy)
            {   
                case "price_lower":
                    movies = db.Movies.OrderBy(s => s.price);
                    break;
                case "price_higher":
                    movies = db.Movies.OrderByDescending(s => s.price);
                    break;
                default:
                    movies = db.Movies.OrderBy(s => s.movieTitle);
                    break;

            }

            return View(movies);
            
        }

        // GET: MovieShowHalls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieShowHall movieShowHall = db.MovieShowHalls.Find(id);
            if (movieShowHall == null)
            {
                return HttpNotFound();
            }
            return View(movieShowHall);
        }

        // GET: MovieShowHalls/Create
        public ActionResult Create()
        {
            ViewBag.Hallid = new SelectList(db.Halls, "id", "id");




            ViewBag.Movieid = new SelectList(db.Movies, "id", "movieTitle");
            return View();
        }

        // POST: MovieShowHalls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Movieid,Hallid,id,date,length")] MovieShowHall movieShowHall)
        {
            if (ModelState.IsValid)
            {
                db.MovieShowHalls.Add(movieShowHall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hallid = new SelectList(db.Halls, "id", "id", movieShowHall.Hallid);
            ViewBag.Movieid = new SelectList(db.Movies, "id", "movieTitle", movieShowHall.Movieid);
            return View(movieShowHall);
        }

        // GET: MovieShowHalls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieShowHall movieShowHall = db.MovieShowHalls.Find(id);
            if (movieShowHall == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hallid = new SelectList(db.Halls, "id", "id", movieShowHall.Hallid);
            ViewBag.Movieid = new SelectList(db.Movies, "id", "movieTitle", movieShowHall.Movieid);
            return View(movieShowHall);
        }
        public ActionResult inTheater(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movieShowHalls = db.MovieShowHalls.Include(m => m.hall).Include(m => m.Movie);
            List<MovieShowHall> list = movieShowHalls.Where(m => m.Movieid == id).ToList();
            if (list == null)
            {
                return HttpNotFound();
            }
            
            return View(list);
        }

        // POST: MovieShowHalls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Movieid,Hallid,id,date,length")] MovieShowHall movieShowHall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieShowHall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hallid = new SelectList(db.Halls, "id", "id", movieShowHall.Hallid);
            ViewBag.Movieid = new SelectList(db.Movies, "id", "movieTitle", movieShowHall.Movieid);
            return View(movieShowHall);
        }

        // GET: MovieShowHalls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieShowHall movieShowHall = db.MovieShowHalls.Find(id);
            if (movieShowHall == null)
            {
                return HttpNotFound();
            }
            return View(movieShowHall);
        }

        // POST: MovieShowHalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieShowHall movieShowHall = db.MovieShowHalls.Find(id);
            db.MovieShowHalls.Remove(movieShowHall);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult BuyTicket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Hall hall = db.Halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            List<SeatList> seatOfTheHall = db.SeatLists.Where(m => m.Hallid == hall.id).ToList();
            return View(seatOfTheHall);
        }
    }
}
