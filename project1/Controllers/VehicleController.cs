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

        // GET: MongoDB/Details/5
        public ActionResult Details(String id)
        {
            var vehicleId = new ObjectId(id);
            var vehicle = vehicleCollection.AsQueryable<VehicleModel>().SingleOrDefault(x => x.Id == vehicleId);

            return View(vehicle);
        }

        // GET: MongoDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MongoDB/Create
        [HttpPost]
        public ActionResult Create(VehicleModel vehicle)
        {
            try
            {
                // TODO: Add insert logic here
                vehicleCollection.InsertOne(vehicle);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MongoDB/Edit/5
        public ActionResult Edit(string id)
        {
            var vehicleId = new ObjectId(id);
            var vehicle = vehicleCollection.AsQueryable<VehicleModel>().SingleOrDefault(x => x.Id == vehicleId);

            return View(vehicle);
        }

        // POST: MongoDB/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, VehicleModel vehicle)
        {
            try
            {
                var filter = Builders<VehicleModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<VehicleModel>.Update
                    .Set("Data and Time", vehicle.Date_and_Time)
                    .Set("Latitude", vehicle.Latitude)
                    .Set("Longitude", vehicle.Longitude)
                    .Set("Car_ID", vehicle.Car_ID);
                var result = vehicleCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MongoDB/Delete/5
        public ActionResult Delete(string id)
        {
            var vehicleId = new ObjectId(id);
            var vehicle = vehicleCollection.AsQueryable<VehicleModel>().SingleOrDefault(x => x.Id == vehicleId);

            return View(vehicle);
        }

        // POST: MongoDB/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, VehicleModel vehicle)
        {
            try
            {
                vehicleCollection.DeleteOne(Builders<VehicleModel>.Filter.Eq("_id", ObjectId.Parse(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
