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
        public ActionResult Index(string searchString)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userSearch = from o in db.Register select o;
                string[] userNames; // declare the array to hold pieces of the string
                if (!String.IsNullOrEmpty(searchString))
                {
                    userNames = searchString.Split(' '); // split the string on spaces
                    if (userNames.Count() == 1) // there is only one string so it could be
                                                // either the first or last name
                    {
                        userSearch = userSearch.Where(c => c.LastName.Contains(searchString) ||
                       c.FirstName.Contains(searchString)).OrderBy(c => c.LastName);
                    }
                    else //if you get here there were at least two strings so extract them and test
                    {
                        string s1 = userNames[0];
                        string s2 = userNames[1];
                        userSearch = userSearch.Where(c => c.LastName.Contains(s2) &&
                       c.FirstName.Contains(s1)).OrderBy(c => c.LastName); // note that this uses &&, not ||
                    }
                }
                
                return View(userSearch.ToList());
            }

            else
            {
                return View("NotAuthenticated");
            }

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
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,EmailAddress,PhoneNumber,Birthday,OGroup,Centric,hireDate")] Registrar registrar)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                registrar.ID = memberID;
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
            Registrar registrar = db.Register.Find(id);
            if (registrar == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if(registrar.ID == memberID)
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
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,EmailAddress,PhoneNumber,Birthday,OGroup,Centric,hireDate")] Registrar registrar)
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
