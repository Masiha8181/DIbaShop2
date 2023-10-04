using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class SubProduct
    {
        [Key]
        public int id { get; set; }

        public int Productid { get; set; }
        [MaxLength(100)]
        [Required]
        public string ProductModelName { get; set; }
        
        [Required]
        public double Price { get; set; }
   
        [Required]
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public int Colorid { get; set; }
        public int Sizeid { get; set; }
        public bool IsInStock { get; set; }
        public bool IsDeleted { get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<ExclusiveOffer> ExclusiveOffers { get; set; }
        public List<Cart> Carts { get; set; }


    }
}
