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


        public ActionResult SubCode()
        {
            var q = db.Courses.ToList();
            return View(q);
        }

       
        public ActionResult Index(int?id)
        {
            Session["courseId"] = id;
            var q = db.LearningPlans.Where(x=>x.Course.CourseId==id).ToList();
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
            lp.CourseId = (int) Session["courseId"];
            db.LearningPlans.Add(lp);
            db.SaveChanges();
            return RedirectToAction("Index", "LessonPlan");
        }
    }
}