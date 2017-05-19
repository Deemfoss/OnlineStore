using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Concrete;
using System.Data.Entity;
using OnlineStore.Domain.IRepository;
namespace OnlineStore.Domain.Concrete
{
  
 public   class StoreRepository:IRepository<Store>
    {       
            private StoreContext db;

            public StoreRepository(StoreContext context)
            {
                this.db = context;
            }

        
             public Store Get(int id)
        {
            
                return db.Stores.Find(id);
            }

            public void Create(Store store)
            {
                db.Stores.Add(store);
            }

            public void Update(Store store)
            {
           
                db.Entry(store).State = EntityState.Modified;
            }

            public void Delete(int id)
            {
                Store store = db.Stores.Find(id);
                if (store != null)
                    db.Stores.Remove(store);
            }
        public void Save()
        {
            db.SaveChanges();
        }

    }

     
}
