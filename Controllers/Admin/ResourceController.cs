using SyllabusMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyllabusMaker.Controllers.Admin
{
    public class ResourceController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: Resource
        public ActionResult Index()
        {
            var q = db.Books.ToList();
            return View(q);
        }
        public ActionResult Create()
        {
            List<BookType> TypeList = db.BookTypes.ToList();
            List<Course> CourseList = db.Courses.ToList();
            ViewBag.TypeList = new SelectList(TypeList, "BooktypeId", "Type");
            ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");

            return View();
        }
        [HttpPost]

        public ActionResult Create(Book b)
        {
            //List<BookType> TypeList = db.BookTypes.ToList();
            //ViewBag.TypeList = new SelectList(TypeList, "BookTypeId", "Type");
            db.Books.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index","Resource");
        }
    

    }
}