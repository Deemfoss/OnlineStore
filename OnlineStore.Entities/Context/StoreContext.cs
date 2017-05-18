using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Entities;
using System.Data.Entity;


namespace OnlineStore.Entities.Context
{
    class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Store { get; set; }
    }
}
