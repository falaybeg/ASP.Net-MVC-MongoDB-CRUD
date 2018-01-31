using MongoDbCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDbCRUD.Models.Respository;

namespace MongoDbCRUD.Controllers
{
    public class ProductController : Controller
    {
        private ProductCollection db = new ProductCollection();

        // GET: Product
        public ActionResult Index()
        {
            var data = db.GetAllProduct();
            return View(data);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.InsertContact(product);

            return RedirectToAction("Index", db.GetAllProduct());
        }

        [HttpGet]
        public ActionResult UpdateProduct(string productId)
        {
            var product = db.GetProductById(productId);

            return View("CreateProduct", product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(string productId, Product product)
        {
            db.UpdateContact(productId, product);
            var allProduct = db.GetAllProduct();

            return RedirectToAction("Index", allProduct);
        }

        [HttpPost]
        public ActionResult DeleteProduct(string productId)
        {
            db.DeleteContact(productId);

            var all = db.GetAllProduct();
            return RedirectToAction("Index",all);
        }

    }
}