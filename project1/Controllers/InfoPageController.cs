using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using trackingSystem.Models;

namespace project1.Controllers
{
    public class InfoPageController : Controller
    {

        public ActionResult InfoPage()
        {
            return View();
        }
    }
}