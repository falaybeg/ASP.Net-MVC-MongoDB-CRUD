using MongoDB.Driver;
using MongoDB.Bson;
using MongoDbCRUD.Models.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDbCRUD.Models
{
    // this class is our Product Collection (Product Table)
    public class ProductCollection
    {
       
        internal MongoDBRespository _repo = new MongoDBRespository();
        public IMongoCollection<Product> Collection;

        public ProductCollection()
        {
            // here we were created new Collection with Products name
            this.Collection = _repo.db.GetCollection<Product>("Products");
        }

        public void InsertContact(Product contact)
        {
            this.Collection.InsertOneAsync(contact);
        }
       
        public List<Product> GetAllProduct()
        {
            var query = this.Collection
                .Find(new BsonDocument())
                .ToListAsync();
            return query.Result;
        }
       
        public Product GetProductById(string id)
        {
            var product = this.Collection.Find(
                    new BsonDocument { { "_id", new ObjectId(id) } })
                    .FirstAsync()
                    .Result;
            return product;
        }
       
        public void UpdateContact(string id, Product contact)
        {
            contact.Id = new ObjectId(id);

            var filter = Builders<Product>
                .Filter
                .Eq(s => s.Id, contact.Id);
            this.Collection.ReplaceOneAsync(filter, contact);

        }

        public void DeleteContact(string productId)
        {
            Product contact = new Product();
            contact.Id = new ObjectId(productId);
            var filter = Builders<Product>.Filter.Eq(s => s.Id, contact.Id);
            this.Collection.DeleteOneAsync(filter);

        }
    }
}