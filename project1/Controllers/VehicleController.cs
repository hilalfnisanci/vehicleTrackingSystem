using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Configuration;
using trackingSystem.App_Start;
using MongoDB.Driver;
using trackingSystem.Models;

namespace trackingSystem.Controllers
{
    public class VehicleController : Controller
    {
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        public ActionResult Index()
        {
            var database = mongoClient.GetDatabase("VehicleDB");
            var collection = database.GetCollection<VehicleModel>("vehicleData");
            List<string> idList = (List<string>)Session["CarIDs"];
            var vehicleResults = collection.Find<VehicleModel>(a => idList.Contains(a.Car_ID)).ToList();

            return View(vehicleResults);
        }
    }
}
