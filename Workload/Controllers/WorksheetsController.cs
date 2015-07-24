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
    public class WorksheetsController : BaseController
    {
        WorksheetRepository WorkRepo = RepositoryHelper.GetWorksheetRepository();

        //private WorkloadEntities1 db = new WorkloadEntities1();

        // GET: Worksheets
        public ActionResult Index(string id)
        {
            //var worksheet = db.Worksheet.Include(w => w.MonthData).Include(w => w.PrjData).Include(w => w.V_Empdata).Include(w => w.V_Empdata1)
            //    .Where(p=>p.Prj==id);
            var worksheet = WorkRepo.GetPrj(id);
            return View(worksheet.ToList());
        }
        
        //[ChildActionOnly]
        public ActionResult WorkloadDetail(string id)
        {
            ViewData["YearData"] = WorkRepo.GetYear(id).ToList();
            ViewData["MonthData"] = WorkRepo.GetMonth(id).ToList();
            ViewData["Emp"] = WorkRepo.GetEmp(id).ToList();
            ViewData["Editor"] = WorkRepo.GetEditor(id).ToList();
            var workload = WorkRepo.GetPrj(id).OrderByDescending(p=>p.V_Empdata.EmpID);
            return View(workload.ToList());
        }

        // GET: Worksheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheet.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(worksheet);
        }

        // GET: Worksheets/Create
        public ActionResult Create()
        {
            ViewBag.Month = new SelectList(db.MonthData, "MonthPK", "Year");
            ViewBag.Prj = new SelectList(db.PrjData, "PrjNo", "PrjE1");
            ViewBag.Editor = new SelectList(db.V_Empdata, "EmpID", "Unit");
            ViewBag.Staff = new SelectList(db.V_Empdata, "EmpID", "Unit");
            return View();
        }

        // POST: Worksheets/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkID,Prj,Staff,Month,Hour,Editor")] Worksheet worksheet)
        {
            if (ModelState.IsValid)
            {
                db.Worksheet.Add(worksheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Month = new SelectList(db.MonthData, "MonthPK", "Year", worksheet.Month);
            ViewBag.Prj = new SelectList(db.PrjData, "PrjNo", "PrjE1", worksheet.Prj);
            ViewBag.Editor = new SelectList(db.V_Empdata, "EmpID", "Unit", worksheet.Editor);
            ViewBag.Staff = new SelectList(db.V_Empdata, "EmpID", "Unit", worksheet.Staff);
            return View(worksheet);
        }

        // GET: Worksheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheet.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Month = new SelectList(db.MonthData, "MonthPK", "Year", worksheet.Month);
            ViewBag.Prj = new SelectList(db.PrjData, "PrjNo", "PrjE1", worksheet.Prj);
            ViewBag.Editor = new SelectList(db.V_Empdata, "EmpID", "Unit", worksheet.Editor);
            ViewBag.Staff = new SelectList(db.V_Empdata, "EmpID", "Unit", worksheet.Staff);
            return View(worksheet);
        }

        // POST: Worksheets/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkID,Prj,Staff,Month,Hour,Editor")] Worksheet worksheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worksheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Month = new SelectList(db.MonthData, "MonthPK", "Year", worksheet.Month);
            ViewBag.Prj = new SelectList(db.PrjData, "PrjNo", "PrjE1", worksheet.Prj);
            ViewBag.Editor = new SelectList(db.V_Empdata, "EmpID", "Unit", worksheet.Editor);
            ViewBag.Staff = new SelectList(db.V_Empdata, "EmpID", "Unit", worksheet.Staff);
            return View(worksheet);
        }

        // GET: Worksheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheet.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(worksheet);
        }

        // POST: Worksheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worksheet worksheet = db.Worksheet.Find(id);
            db.Worksheet.Remove(worksheet);
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
