using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Domain.Concrete;
using OnlineStore.Domain.Entities;
using System.Data.Entity;
using OnlineStore.Domain.IRepository;
using Vereyon.Web;
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
            if (ModelState.IsValid)
            {
                productrep.Proucts.Create(product);
                productrep.Proucts.Save();
                FlashMessage.Confirmation("The product was created successfully");
            }
           
           
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
            if (ModelState.IsValid)
            {
                storrep.Stores.Create(store);
                storrep.Stores.Save();
                FlashMessage.Confirmation("The store was created successfully");
            }
            return RedirectToAction("Index");
        }

        
      [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                productrep.Proucts.Delete(id);
                productrep.Proucts.Save();
                FlashMessage.Danger("The product was deleted successfully");
            }
            return RedirectToAction("Index");
        }


       [HttpPost]
        public ActionResult DeleteStore(int id)
        {
            if (ModelState.IsValid)
            {
                storrep.Stores.Delete(id);
                storrep.Stores.Save();
                FlashMessage.Info("The Store was deleted successfully");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditStore(int id)
        {


            var res = storrep.Stores.Get(id);

            return View(res);
        }


        [HttpPost]
        public ActionResult EditStore(Store store)
        {
            if (ModelState.IsValid)
            {
                storrep.Stores.Update(store);
                productrep.Proucts.Save();
                FlashMessage.Warning("The Store was changed successfully");
            }
            return RedirectToAction("Index");
        }



    }
}