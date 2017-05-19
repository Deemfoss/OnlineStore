using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Domain.Concrete;
using OnlineStore.Domain.Entities;
using System.Data.Entity;
using OnlineStore.Domain.IRepository;
namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository productrep;
        IStoreRepository storrep;
        public HomeController()
        {
            productrep = new IProductRepository();
            storrep = new IStoreRepository();
        }

        StoreContext db = new StoreContext();

        public ActionResult Index()
        {
             
            
            return View(db.Stores);
        }

       
        public ActionResult Edit(int id)
        {
            var res = db.Products.Include(p => p.Store).Where(d => d.IdStore == id).ToList();
       
            return PartialView(res);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            SelectList products = new SelectList(db.Stores, "Id", "Name");
            ViewBag.Products = products;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            productrep.Proucts.Create(product);
            productrep.Proucts.Save();
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateStore()
        { 
          
            return View();
        }

        [HttpPost]
        public ActionResult CreateStore(Store store)
        {
            storrep.Stores.Create(store);
            storrep.Stores.Save();
            
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditProduct(int id)
        {
           

            var res= productrep.Proucts.Get(id);
            SelectList products = new SelectList(db.Stores, "Id", "Name",res.Name);
            return View(res);
        }


        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            productrep.Proucts.Update(product);
            productrep.Proucts.Save();

            return RedirectToAction("Index");
        }


      [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            productrep.Proucts.Delete(id);
            productrep.Proucts.Save();

            return RedirectToAction("Index");
        }


       [HttpPost]
        public ActionResult DeleteStore(int id)
        {
            storrep.Stores.Delete(id);
            storrep.Stores.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditStore(int id)
        {


            var res = storrep.Stores.Get(id);

            return View(res);
        }


        [HttpPost]
        public ActionResult EditStorre(Store store)
        {
            storrep.Stores.Update(store);
            productrep.Proucts.Save();

            return RedirectToAction("Index");
        }



    }
}