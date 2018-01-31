using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MongoDbCRUD.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [Required]
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [Required]
        [BsonElement("BarcodeNumber")]
        public string BarcodeNumber { get; set; }
        [Required]
        [BsonElement("Quantity")]
        public string Quantity { get; set; }

    }
}