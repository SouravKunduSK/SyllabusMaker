using SyllabusMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyllabusMaker.Controllers.Admin
{
    public class LessonPlanController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: LessonPlan
        public ActionResult Index()
        {
            var q = db.LearningPlans.ToList();
            return View(q);
        }

        public ActionResult Create()
        {
            List<Course> CourseList = db.Courses.ToList();
            ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");
            return View();
        }
        [HttpPost]
        public ActionResult Create(LearningPlan lp)
        {
            //List<Course> CourseList = db.Courses.ToList();
            //ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");
            db.LearningPlans.Add(lp);
            db.SaveChanges();
            return RedirectToAction("Index", "LessonPlan");
        }
    }
}