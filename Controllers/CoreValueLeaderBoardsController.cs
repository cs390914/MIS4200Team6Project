using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MIS4200Team6.DAL;
using MIS4200Team6.Models;
using System.Net;
using System.Net.Mail;
using System;

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
            ViewBag.ID = new SelectList(db.Register, "ID", "EmailAddress");
            return View();
        }

        // POST: CoreValueLeaderBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "leaderboardID,ID,Stewardship,Culture,Delivery_Excellence,Innovation,Greater_Good,Integrity_And_Openness,Balance")] CoreValueLeaderBoard coreValueLeaderBoard)
        {
            if (ModelState.IsValid)
            {
                db.coreValueLeaderBoards.Add(coreValueLeaderBoard);
                db.SaveChanges();
                var email = db.Register.Find(coreValueLeaderBoard.ID).EmailAddress;
                SmtpClient myClient = new SmtpClient();
                
                myClient.Credentials = new NetworkCredential("jakebutler67@gmail.com", "Snakira67!");
                MailMessage myMessage = new MailMessage();
                
                MailAddress from = new MailAddress("jakebutler67@gmail.com", "SysAdmin");
                myMessage.From = from;
                myMessage.From = new MailAddress(email.ToString());
                myMessage.To.Add(email); // this should be replaced with model data
                                                            // as shown at the end of this document
                myMessage.Subject = "MVC Email test";
                // the body of the email is hard coded here but could be dynamically created using data
                // from the model- see the note at the end of this document
                myMessage.Body = "This is the body of the mail message. This can be essentially any length, and could come ";
                myMessage.Body += "from the database, a variable, the return of another method...";
                try
                {
                    myClient.Send(myMessage);
                    TempData["mailError"] = "";
                }
                catch (Exception ex)

                {
                    // this captures an Exception and allows you to display the message in the View
                    TempData["mailError"] = ex.Message;
                }

                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Register, "ID", "EmailAddress", coreValueLeaderBoard.ID);
            


         
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
            ViewBag.ID = new SelectList(db.Register, "ID", "EmailAddress", coreValueLeaderBoard.ID);
            return View(coreValueLeaderBoard);
        }

        // POST: CoreValueLeaderBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "leaderboardID,ID,Stewardship,Culture,Delivery_Excellence,Innovation,Greater_Good,Integrity_And_Openness,Balance")] CoreValueLeaderBoard coreValueLeaderBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValueLeaderBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Register, "ID", "EmailAddress", coreValueLeaderBoard.ID);
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
