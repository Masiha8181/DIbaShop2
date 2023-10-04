using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Discount
    {
        [Key]
        [Required]
        public int id { get; set; }

        public int SubProductid { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime DiscountStart { get; set; }
        public DateTime DiscountEnd { get; set; }
        public SubProduct SubProduct { get; set; }
    }
}
