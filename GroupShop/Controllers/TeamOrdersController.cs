using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupShop.Models;

namespace GroupShop.Controllers
{
    public class TeamOrdersController : Controller
    {
        private TeambuyDbContext db = new TeambuyDbContext();

        // GET: TeamOrders
        public ActionResult Index()
        {
            return View(db.TeamOrders.ToList());
        }

        public ActionResult SingleTeamIndex(string teamId)
        {

            return View("Index",db.TeamOrders.Where(m=>m.TeamId == teamId).ToList());
        }

        // GET: TeamOrders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamOrder teamOrder = db.TeamOrders.Find(id);
            if (teamOrder == null)
            {
                return HttpNotFound();
            }
            return View(teamOrder);
        }

        // GET: TeamOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,TeamId,ProductId,Amount,Quantity")] TeamOrder teamOrder)
        {
            if (ModelState.IsValid)
            {
                db.TeamOrders.Add(teamOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamOrder);
        }

        // GET: TeamOrders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamOrder teamOrder = db.TeamOrders.Find(id);
            if (teamOrder == null)
            {
                return HttpNotFound();
            }
            return View(teamOrder);
        }

        // POST: TeamOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,TeamId,ProductId,Amount,Quantity")] TeamOrder teamOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamOrder);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuantity([Bind(Include = "MemberId,TeamId,ProductId,Quantity")] TeamOrder teamOrder)
        {
            if (ModelState.IsValid)
            {
                    db.Entry(teamOrder).State = EntityState.Modified;
                    db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(teamOrder);
        }

        // GET: TeamOrders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamOrder teamOrder = db.TeamOrders.Find(id);
            if (teamOrder == null)
            {
                return HttpNotFound();
            }
            return View(teamOrder);
        }

        // POST: TeamOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TeamOrder teamOrder = db.TeamOrders.Find(id);
            db.TeamOrders.Remove(teamOrder);
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
