using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using MongoDB.Driver;
using trackingSystem.Models;

namespace project1.Controllers
{
    public class MapPageController : Controller
    {
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
        // GET: MapPage
        public ActionResult MapPage()
        {
            var database = mongoClient.GetDatabase("VehicleDB");
            var collection = database.GetCollection<VehicleModel>("vehicleData");
            List<string> idList = (List<string>)Session["CarIDs"];
            string markers = "[";
            var vehicleResults = collection.Find<VehicleModel>(a => idList.Contains(a.Car_ID)).ToList();

            int count = 0;
            foreach (var vehicle in vehicleResults)
            {
                if (count == 30)
                    break;
                markers += "{";
                markers += string.Format("'title': '{0}',", vehicle.Id);
                markers += string.Format("'lat': '{0}',", vehicle.Latitude);
                markers += string.Format("'lng': '{0}',", vehicle.Longitude);
                markers += "},";
                count++;
            }
            markers += "];";

            ViewBag.Markers = markers;

            return View(vehicleResults);
        }
    }
}