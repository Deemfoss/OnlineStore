using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Concrete;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Concrete
{
    public class IProductsRepository
    {
        private StoreContext db = new StoreContext();
        private ProductRepository productRepository;
        public ProductRepository Proucts
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
    }
}
