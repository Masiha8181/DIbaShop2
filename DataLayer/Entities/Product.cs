using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public int id { get; set; }
        [MaxLength(100)]
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string ShortProductDescription { get; set; }
        public int SellCount { get; set; }

        [Required]
        public string MainProductImage { get; set; }
        public bool? IsInStock { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductInfo> ProductInfos { get; set; }





    }
}
