using SyllabusMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyllabusMaker.Controllers.Admin
{
    public class CourseObjectivesController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: CourseObjectives
        public ActionResult Index()
        {
            var q = db.CourseObjectives.ToList();
            return View(q);
        }

        public ActionResult Create()
        {
            List<Course> CourseList = db.Courses.ToList();
            ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");
            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseObjective co)
        {
            //List<Course> CourseList = db.Courses.ToList();
            //ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");
            db.CourseObjectives.Add(co);
            db.SaveChanges();
            return RedirectToAction("Index", "CourseObjectives");
        }
    }
}