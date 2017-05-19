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
  
 public   class ProductRepository:IRepository<Product>
    {       
            private StoreContext db;

            public ProductRepository(StoreContext context)
            {
                this.db = context;
            }

        
             public Product Get(int id)
            {
                return db.Products.Find(id);
            }

            public void Create(Product product)
            {
                db.Products.Add(product);
            }

            public void Update(Product product)
            {
           
                db.Entry(product).State = EntityState.Modified;
            }

            public void Delete(int id)
            {
                Product product = db.Products.Find(id);
                if (product != null)
                    db.Products.Remove(product);
            }
        public void Save()
        {
            db.SaveChanges();
        }

    }

     
}
