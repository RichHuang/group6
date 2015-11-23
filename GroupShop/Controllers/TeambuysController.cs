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
    public class TeambuysController : Controller
    {
        private TeambuyDbContext db = new TeambuyDbContext();

        // GET: Teambuys
        public ActionResult Index()
        {
            return View(db.Teambuys.ToList());
        }

        // GET: Teambuys/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teambuy teambuy = db.Teambuys.Find(id);
            if (teambuy == null)
            {
                return HttpNotFound();
            }
            return View(teambuy);
        }

        // GET: Teambuys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teambuys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,MemberId,Startdate,Enddate,LeastAmount,Status")] Teambuy teambuy)
        {
            if (ModelState.IsValid && Session["LoginMemberId"] != null)
            {
                if (teambuy.MemberId == null) {
                    teambuy.MemberId = Session["LoginMemberId"].ToString();
                }
                teambuy.Startdate = DateTime.Now;
                teambuy.Status = "1";

                db.Teambuys.Add(teambuy);
                db.SaveChanges();

                ProductDbContext productDb = new ProductDbContext();

                string supplierId = Request["SupplierId"];
                foreach (Product product in productDb.Products.Where(m=>m.SupplierId == supplierId).ToList()) {
                    TeamOrder teamOrder = new TeamOrder();
                    teamOrder.MemberId = Session["LoginMemberId"].ToString();
                    teamOrder.Quantity = 0;
                    teamOrder.Amount = 0;
                    teamOrder.TeamId = teambuy.TeamId;
                    teamOrder.ProductId = product.ProductId;

                    db.TeamOrders.Add(teamOrder);
                    db.SaveChanges();
                }
               


               



                return RedirectToAction("Index");
            }

            return View(teambuy);
        }

        public ActionResult Cancel(string teamId)
        {
            Teambuy teambuy = db.Teambuys.SingleOrDefault(m => m.TeamId == teamId);
            if (teambuy != null) {
                teambuy.Status = "3";
                db.Entry(teambuy).State = EntityState.Modified;

                db.SaveChanges();
            }
            return RedirectToAction("Index","Home",null);
        }

        // GET: Teambuys/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teambuy teambuy = db.Teambuys.Find(id);
            if (teambuy == null)
            {
                return HttpNotFound();
            }
            return View(teambuy);
        }

        // POST: Teambuys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,MemberId,Startdate,Enddate,LeastAmount,Status")] Teambuy teambuy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teambuy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teambuy);
        }

        // GET: Teambuys/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teambuy teambuy = db.Teambuys.Find(id);
            if (teambuy == null)
            {
                return HttpNotFound();
            }
            return View(teambuy);
        }

        // POST: Teambuys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Teambuy teambuy = db.Teambuys.Find(id);
            db.Teambuys.Remove(teambuy);
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
