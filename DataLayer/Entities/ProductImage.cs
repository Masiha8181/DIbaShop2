using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductImage
    {
        [Key]
        public int id { get; set; }

        public int Productid { get; set; }
      
        [Required]
        public string ImageAddress { get; set; }
        public Product Product { get; set; }
    }
}
