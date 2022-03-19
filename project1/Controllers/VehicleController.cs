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
        private MongoDBContext dbcontext;
        private IMongoCollection<VehicleModel> vehicleCollection;

        public VehicleController()
        {
            dbcontext = new MongoDBContext();
            vehicleCollection = dbcontext.database.GetCollection<VehicleModel>("vehicle");
        }

        // GET: Vehicles
        public ActionResult Index()
        {
            List<VehicleModel> vehicles = vehicleCollection.AsQueryable<VehicleModel>().ToList();
            return View(vehicles);
        }
    }
}
