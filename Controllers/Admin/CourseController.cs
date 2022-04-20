using SyllabusMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyllabusMaker.Controllers.Admin
{
    public class CourseController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: Course
        public ActionResult Index()
        {
            var q = db.Courses.ToList();
            return View(q);
        }

        public ActionResult Create()
        {
            List<CourseType> TypeList = db.CourseTypes.ToList();
            ViewBag.TypeList = new SelectList(TypeList, "CourseTypeId", "Type");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course c)
        {
            List<CourseType> TypeList = db.CourseTypes.ToList();
            ViewBag.TypeList = new SelectList(TypeList, "CourseTypeId", "Type");
            db.Courses.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
    }
}