using SyllabusMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyllabusMaker.Controllers.Admin
{
    public class CIEController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: CIE
        public ActionResult Index()
        {
            
            return View();
        }
    }
}