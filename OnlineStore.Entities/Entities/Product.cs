using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineStore.Domain.Entities
{
    public class Product
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
       
        public int Id { get; set; }
        [Required(ErrorMessage ="Please add Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please add Description")]
        public string Description { get; set; }
        [ForeignKey("Store")]
        [Required(ErrorMessage = "Please add store")]
    
        public int IdStore { get; set; }
        public Store Store { get; set; }
    }
}
