using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Domain.Concrete;
using OnlineStore.Domain.Entities;
namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        IProductsRepository productrep;
        public HomeController()
        {
            productrep = new IProductsRepository();
        }

        StoreContext db = new StoreContext();

        public ActionResult Index()
        {
             
            
            return View(db.Stores);
        }

       
        public ActionResult Edit(int id)
        {
            var res = db.Products.Where(i => i.IdStore == id).ToList();

            return PartialView(res);
        }
    
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            productrep.Proucts.Create(product);
            productrep.Proucts.Save();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateProduct()
        { 
          
            return View();
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