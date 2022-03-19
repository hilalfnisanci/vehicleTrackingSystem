using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace project1.Controllers
{
    public class MapPageController : Controller
    {
        // GET: MapPage
        public ActionResult MapPage()
        {
            var markers = Session["Markers"];
            ViewBag.Markers = markers;
            return View();
        }
    }
}