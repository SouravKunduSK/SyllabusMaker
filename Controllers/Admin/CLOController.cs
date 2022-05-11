using SyllabusMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyllabusMaker.Controllers.Admin
{
    public class CLOController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: CLO
        public ActionResult Index()
        {
            var q = db.CLOes.ToList();
            return View(q);
        }

        public ActionResult Create()
        {
            List<Course> CourseList = db.Courses.ToList();
            ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");
            return View();
        }
        [HttpPost]
        public ActionResult Create(CLO clo)
        {
            //List<Course> CourseList = db.Courses.ToList();
            //ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");
            db.CLOes.Add(clo);
            db.SaveChanges();
            return RedirectToAction("Index", "CLO");
        }
    }
}