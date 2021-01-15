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
    public class SeatListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SeatLists
        public ActionResult Index()
        {
            var seatLists = db.SeatLists.Include(s => s.hall);
            return View(seatLists.ToList());
        }

        // GET: SeatLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatList seatList = db.SeatLists.Find(id);
            if (seatList == null)
            {
                return HttpNotFound();
            }
            return View(seatList);
        }

        // GET: SeatLists/Create
        public ActionResult Create()
        {
            ViewBag.Hallid = new SelectList(db.Halls, "id", "id");
            return View();
        }

        // POST: SeatLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,seatNumber,IsAvailable,Hallid")] SeatList seatList)
        {
            if (ModelState.IsValid)
            {
                db.SeatLists.Add(seatList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hallid = new SelectList(db.Halls, "id", "id", seatList.Hallid);
            return View(seatList);
        }

        // GET: SeatLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatList seatList = db.SeatLists.Find(id);
            if (seatList == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hallid = new SelectList(db.Halls, "id", "id", seatList.Hallid);
            return View(seatList);
        }

        // POST: SeatLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,seatNumber,IsAvailable,Hallid")] SeatList seatList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seatList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hallid = new SelectList(db.Halls, "id", "id", seatList.Hallid);
            return View(seatList);
        }

        // GET: SeatLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatList seatList = db.SeatLists.Find(id);
            if (seatList == null)
            {
                return HttpNotFound();
            }
            return View(seatList);
        }

        // POST: SeatLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeatList seatList = db.SeatLists.Find(id);
            db.SeatLists.Remove(seatList);
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
    }
}
