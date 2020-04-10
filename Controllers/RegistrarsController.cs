using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200Team6.DAL;
using MIS4200Team6.Models;

namespace MIS4200Team6.Controllers
{
    public class RegistrarsController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Registrars
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Register.ToList());
            }
            else
            {
                return View("NotAuthenticated");
            }

            //return View(db.Register.ToList());
        }

        // GET: Registrars/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrar registrar = db.Register.Find(id);
            if (registrar == null)
            {
                return HttpNotFound();
            }
            return View(registrar);
        }

        // GET: Registrars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registrars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,firstName,lastName,PhoneNumber,OperatingGroup,OGroup,Position,hireDate")] Registrar registrar)
        {
            if (ModelState.IsValid)
            {
                registrar.ID = Guid.NewGuid();
                db.Register.Add(registrar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrar);
        }

        // GET: Registrars/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Registrar registrar = db.Register.Find(id);
            //if (registrar == null)
            //{
            //return HttpNotFound();
            //}
            //return View(registrar);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrar registrar = db.Register.Find(id);
            if (registrar == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (registrar.ID == memberID)
            {
                return View(registrar);
            }
            else
            {
                return View("NotAuthenticated");
            }
        }

        // POST: Registrars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,firstName,lastName,PhoneNumber,OperatingGroup,OGroup,Position,hireDate")] Registrar registrar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrar);
        }

        // GET: Registrars/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrar registrar = db.Register.Find(id);
            if (registrar == null)
            {
                return HttpNotFound();
            }
            return View(registrar);
        }

        // POST: Registrars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Registrar registrar = db.Register.Find(id);
            db.Register.Remove(registrar);
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
