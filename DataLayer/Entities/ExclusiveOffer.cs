using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ExclusiveOffer
    {
        [Key]
        [Required]
        public int id { get; set; }
        public int SubProductid { get; set; }
        public int OfferPercent { get; set; }
        public DateTime OfferStart { get; set; }
        public DateTime OfferEnd { get; set; }
        public SubProduct SubProduct { get; set; }
    }
}
