using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace trackingSystem.Models
{
    public class VehicleModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Date and Time")]
        public String Date_and_Time { get; set; }

        [BsonElement("Latitude")]
        public String Latitude { get; set; }

        [BsonElement("Longitude")]
        public String Longitude { get; set; }
        
        [BsonElement("Car_ID")]
        public int Car_ID { get; set; }
    }
}