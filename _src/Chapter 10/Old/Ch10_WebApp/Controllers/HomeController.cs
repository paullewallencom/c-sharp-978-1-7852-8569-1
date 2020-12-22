using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Ch10_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new Models.Northwind())
            {
                var model = new Models.HomeIndexViewModel
                {
                    VisitorCount = (new Random()).Next(500, 901),
                    Products = db.Products.ToArray()
                };
                return View(model); // pass model to view
            }
        }

        public ActionResult ProductDetail(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
            }
            using (var db = new Models.Northwind())
            {
                var model = db.Products.SingleOrDefault(p => p.ProductID == id);
                if (model == null)
                {
                    return HttpNotFound($"A product with the ID of {id} was not found.");
                }
                return View(model); // pass model to view
            }
        }

        public ActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return HttpNotFound("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=50");
            }
            using (var db = new Models.Northwind())
            {
                var model = db.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => p.UnitPrice > price).ToArray();
                if (model.Count() == 0)
                {
                    return HttpNotFound($"No products cost more than {price:C}.");
                }
                return View(model); // pass model to view
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}