using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineStore.Domain.Entities
{
    public class Store
    {
       
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please add Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please add Adress")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Please add work time")]
        public string WorkTime { get; set; }

        public   ICollection<Product> Products { get; set; }
        public Store()
        {
            Products = new List<Product>();
        }
    }
}
