using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductInfo
    {
        [Key]
        public int id { get; set; }

        public int Productid { get; set; }
        [MaxLength(50)]
        [Required]
        public string ProductInfoTitle { get; set; }
       
        [Required]
        public string ProductInfoValue { get; set; }
        public Product Product { get; set; }

    }
}
