using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Concrete;
using System.Data.Entity;

namespace OnlineStore.Domain.Concrete
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
 public   class ProductRepository:IRepository<Product>
    {       
            private StoreContext db;

            public ProductRepository(StoreContext context)
            {
                this.db = context;
            }

            public IEnumerable<Product> GetAll()
            {
                return db.Products;
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
