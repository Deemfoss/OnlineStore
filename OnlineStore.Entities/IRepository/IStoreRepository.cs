using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Concrete;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.IRepository

{
    public class IStoreRepository
    {
        private StoreContext db = new StoreContext();
        private StoreRepository storeRepository;
        public StoreRepository Stores
        {
            get
            {
                if (storeRepository == null)
                    storeRepository = new StoreRepository(db);
                return storeRepository;
            }
        }
    }
}
