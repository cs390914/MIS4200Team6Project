using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Team6.DAL;
using MIS4200Team6.Models;

namespace MIS4200Team6.Controllers
{
    public class CoreValueLeaderBoardsController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: CoreValueLeaderBoards
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var coreValueLeaderBoards = db.coreValueLeaderBoards.Include(c => c.Registrar);
                return View(coreValueLeaderBoards.ToList());
                
            }
            else
            {
                return View("NotAuthenticated");
            }

            
        }

        // GET: CoreValueLeaderBoards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValueLeaderBoard coreValueLeaderBoard = db.coreValueLeaderBoards.Find(id);
            if (coreValueLeaderBoard == null)
            {
                return HttpNotFound();
            }
            return View(coreValueLeaderBoard);
        }

        // GET: CoreValueLeaderBoards/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Register, "ID", "FirstName");
            return View();
        }

        // POST: CoreValueLeaderBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "leaderboardID,ID,Centric,Comment,TodaysDate")] CoreValueLeaderBoard coreValueLeaderBoard)
        {
            if (ModelState.IsValid)
            {
                db.coreValueLeaderBoards.Add(coreValueLeaderBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Register, "ID", "FirstName", coreValueLeaderBoard.ID);
            return View(coreValueLeaderBoard);
        }

        // GET: CoreValueLeaderBoards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValueLeaderBoard coreValueLeaderBoard = db.coreValueLeaderBoards.Find(id);
            if (coreValueLeaderBoard == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Register, "ID", "FirstName", coreValueLeaderBoard.ID);
            return View(coreValueLeaderBoard);
        }

        // POST: CoreValueLeaderBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "leaderboardID,ID,Centric,Comment,TodaysDate")] CoreValueLeaderBoard coreValueLeaderBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValueLeaderBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Register, "ID", "FirstName", coreValueLeaderBoard.ID);
            return View(coreValueLeaderBoard);
        }

        // GET: CoreValueLeaderBoards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValueLeaderBoard coreValueLeaderBoard = db.coreValueLeaderBoards.Find(id);
            if (coreValueLeaderBoard == null)
            {
                return HttpNotFound();
            }
            return View(coreValueLeaderBoard);
        }

        // POST: CoreValueLeaderBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoreValueLeaderBoard coreValueLeaderBoard = db.coreValueLeaderBoards.Find(id);
            db.coreValueLeaderBoards.Remove(coreValueLeaderBoard);
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
