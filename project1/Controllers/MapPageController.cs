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
            
            DateTime date = DateTime.Now;
            int min = date.Hour * 60 + date.Minute;
            List<VehicleModel> carsList = new List<VehicleModel>();
            List<VehicleModel> locations = collection.Find<VehicleModel>(a => idList.Contains(a.Car_ID)).ToList();
            
            foreach(var loc in locations)
            {
                var carDate = loc.Date_and_Time.Split(' ');
                if (Int32.Parse(carDate[1].Split(':')[0]) * 60 + Int32.Parse(carDate[1].Split(':')[1]) <= min && Int32.Parse(carDate[1].Split(':')[0]) * 60 + Int32.Parse(carDate[1].Split(':')[1]) > min - 30)
                {
                    carsList.Add(loc);
                }
            }

            return View(carsList);
        }
        public ActionResult DateQuery(int userID, string start, string end)
        {
            var database = mongoClient.GetDatabase("VehicleDB");
            var collection = database.GetCollection<VehicleModel>("vehicleData");
            List<string> idList = (List<string>)Session["CarIDs"];

            int min1 = Int32.Parse(start.Split(':')[0])* 60 + Int32.Parse(start.Split(':')[1]);
            int min2 = Int32.Parse(end.Split(':')[0]) * 60 + Int32.Parse(end.Split(':')[1]);

            List<VehicleModel> carsList = new List<VehicleModel>();
            List<VehicleModel> locations = collection.Find<VehicleModel>(a => idList.Contains(a.Car_ID)).ToList();

            foreach (var loc in locations)
            {
                var carDate = loc.Date_and_Time.Split(' ');
                if (min1 > min2)
                {

                    if (Int32.Parse(carDate[1].Split(':')[0]) * 60 + Int32.Parse(carDate[1].Split(':')[1]) <= min1 && Int32.Parse(carDate[1].Split(':')[0]) * 60 + Int32.Parse(carDate[1].Split(':')[1]) > min2)
                    {
                        carsList.Add(loc);
                    }
                }
                else
                {
                    if (Int32.Parse(carDate[1].Split(':')[0]) * 60 + Int32.Parse(carDate[1].Split(':')[1]) <= min2 && Int32.Parse(carDate[1].Split(':')[0]) * 60 + Int32.Parse(carDate[1].Split(':')[1]) > min1)
                    {
                        carsList.Add(loc);
                    }
                }
            }
            return View(carsList);
        }
    }
}