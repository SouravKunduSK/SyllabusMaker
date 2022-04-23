using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SyllabusMaker.Models;

namespace SyllabusMaker.Controllers.Admin
{
    public class CLOesController : Controller
    {
        private SyllabusMakerEntities db = new SyllabusMakerEntities();

        // GET: CLOes
        public ActionResult Index()
        {
            var cLOes = db.CLOes.Include(c => c.Course);
            return View(cLOes.ToList());
        }

        // GET: CLOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLO cLO = db.CLOes.Find(id);
            if (cLO == null)
            {
                return HttpNotFound();
            }
            return View(cLO);
        }

        // GET: CLOes/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            return View();
        }

        // POST: CLOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLOId,Outcomes,CourseId")] CLO cLO)
        {
            if (ModelState.IsValid)
            {
                db.CLOes.Add(cLO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", cLO.CourseId);
            return View(cLO);
        }

        // GET: CLOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLO cLO = db.CLOes.Find(id);
            if (cLO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", cLO.CourseId);
            return View(cLO);
        }

        // POST: CLOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLOId,Outcomes,CourseId")] CLO cLO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", cLO.CourseId);
            return View(cLO);
        }

        // GET: CLOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLO cLO = db.CLOes.Find(id);
            if (cLO == null)
            {
                return HttpNotFound();
            }
            return View(cLO);
        }

        // POST: CLOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLO cLO = db.CLOes.Find(id);
            db.CLOes.Remove(cLO);
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
