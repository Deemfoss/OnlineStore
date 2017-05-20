using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Concrete;
namespace OnlineStore.Controllers
{
    public class WebApiController : ApiController
    {
        
        StoreContext db = new StoreContext();

        public IEnumerable<Store> GetStores()
        {
            return db.Stores;
        }

       

    }
}
