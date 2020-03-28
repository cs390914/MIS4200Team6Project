﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Team6.DAL;
using MIS4200Team6.Models;
using Microsoft.AspNet.Identity;

namespace MIS4200Team6.Controllers
{
    public class RegistrarsController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        private object regeistar;

        // GET: Registrars
        public ActionResult Index()
        {

            return View(db.Register.ToList());
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
        public ActionResult Create([Bind(Include = "ID,Email,firstName,lastName,PhoneNumber,Position,hireDate")] Registrar registrar)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                registrar.ID = memberID;
                db.Register.Add(registrar);
                //db.SaveChanges will throw an Exception if the user already exists
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View("DuplicateUser");
                }


                //Guid memberID;
                //Guid.TryParse(User.Identity.GetUserId(), out memberID);
                //regeistar.ID = memberID;
                //db.Regeistars.Add(regeistar);
                //db.SaveChanges();
                //return RedirectToAction("Index");

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
            Registrar registrar = db.Register.Find(id);
            if (registrar == null)
            {
                return HttpNotFound();
            }
            return View(registrar);
        }

        // POST: Registrars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,firstName,lastName,PhoneNumber,Position,hireDate")] Registrar registrar)
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