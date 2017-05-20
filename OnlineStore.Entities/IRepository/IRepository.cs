using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineStore.Domain.IRepository
{
    
     public   interface IRepository<T> where T : class
        {
           
            T Get(int id);
            void Create(T item);
            void Update(T item);
            void Delete(int id);
            void Save();
        }
    
}
