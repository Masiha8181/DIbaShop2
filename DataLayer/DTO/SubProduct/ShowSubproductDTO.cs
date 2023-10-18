using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.SubProduct
{
    public class ShowSubproductDTO
    {
        [Key]
        public int id { get; set; }

        public int Productid { get; set; }
        [MaxLength(100)]
        [Required]
        public string ProductModelName { get; set; }

        [Required]
        public decimal Price { get; set; }
        public int? DiscountPercent { get; set; }
        public DateTime? DiscountStart { get; set; }
        public DateTime? DiscountEnd { get; set; }
        public bool? IsHaveActiveDIscount { get; set; }
        public decimal? DiscountAfterPrice
        {
            get
            {
                return (Price * DiscountPercent) / 100;
            }

        }
        [Required]
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public int Colorid { get; set; }
        public int Sizeid { get; set; }
        public bool IsInStock { get; set; }
        public bool IsDeleted { get; set; }
    
        public Entities.Color Color { get; set; }
        public Entities.Size Size { get; set; }
  
    }
}
