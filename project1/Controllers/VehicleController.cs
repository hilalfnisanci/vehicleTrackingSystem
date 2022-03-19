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
            string markers = "[";
            var vehicleResults = collection.Find<VehicleModel>(a => idList.Contains(a.Car_ID)).ToList();
            
            int count = 0;
            foreach(var vehicle in vehicleResults)
            {
                markers += "{";
                markers += string.Format("'title': '{0}',", vehicle.Id);
                markers += string.Format("'lat': '{0}',", vehicle.Latitude);
                markers += string.Format("'lng': '{0}',", vehicle.Longitude);
                markers += string.Format("'description': '{0}'", vehicle.Car_ID);
                markers += "},";
                count++;
                if (count == 30)
                    break;
            }
            markers += "];";
            Session["Markers"] = markers;

            return View(vehicleResults);
        }
    }
}
