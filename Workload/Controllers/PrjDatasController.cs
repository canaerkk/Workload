using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workload.Models;

namespace Workload.Controllers
{
    public class PrjDatasController : Controller
    {
        private WorkloadEntities1 db = new WorkloadEntities1();

        // GET: PrjDatas
        public ActionResult Index()
        {
            var prjData = db.PrjData.Include(p => p.MonthData).Include(p => p.MonthData1).Include(p => p.V_Empdata);
            return View(prjData.ToList());
        }

        // GET: PrjDatas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrjData prjData = db.PrjData.Find(id);
            if (prjData == null)
            {
                return HttpNotFound();
            }
            return View(prjData);
        }

        // GET: PrjDatas/Create
        public ActionResult Create()
        {
            ViewBag.PrjStart = new SelectList(db.MonthData, "MonthPK", "Year");
            ViewBag.PrjEnd = new SelectList(db.MonthData, "MonthPK", "Year");
            ViewBag.Editor = new SelectList(db.V_Empdata, "EmpID", "Unit");
            return View();
        }

        // POST: PrjDatas/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrjNo,PrjE1,PrjName,PrjStart,PrjEnd,Editor,Status")] PrjData prjData)
        {
            if (ModelState.IsValid)
            {
                db.PrjData.Add(prjData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrjStart = new SelectList(db.MonthData, "MonthPK", "Year", prjData.PrjStart);
            ViewBag.PrjEnd = new SelectList(db.MonthData, "MonthPK", "Year", prjData.PrjEnd);
            ViewBag.Editor = new SelectList(db.V_Empdata, "EmpID", "Unit", prjData.Editor);
            return View(prjData);
        }

        // GET: PrjDatas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrjData prjData = db.PrjData.Find(id);
            if (prjData == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrjStart = new SelectList(db.MonthData, "MonthPK", "Year", prjData.PrjStart);
            ViewBag.PrjEnd = new SelectList(db.MonthData, "MonthPK", "Year", prjData.PrjEnd);
            ViewBag.Editor = new SelectList(db.V_Empdata, "EmpID", "Unit", prjData.Editor);
            return View(prjData);
        }

        // POST: PrjDatas/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrjNo,PrjE1,PrjName,PrjStart,PrjEnd,Editor,Status")] PrjData prjData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prjData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrjStart = new SelectList(db.MonthData, "MonthPK", "Year", prjData.PrjStart);
            ViewBag.PrjEnd = new SelectList(db.MonthData, "MonthPK", "Year", prjData.PrjEnd);
            ViewBag.Editor = new SelectList(db.V_Empdata, "EmpID", "Unit", prjData.Editor);
            return View(prjData);
        }

        // GET: PrjDatas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrjData prjData = db.PrjData.Find(id);
            if (prjData == null)
            {
                return HttpNotFound();
            }
            return View(prjData);
        }

        // POST: PrjDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PrjData prjData = db.PrjData.Find(id);
            db.PrjData.Remove(prjData);
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
