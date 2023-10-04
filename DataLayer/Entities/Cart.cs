using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Cart
    {
        [Key] public int id { get; set; }
        public int Orderid { get; set; }
        public int SubProductid { get; set; }
       
        public int Count { get; set; }
        public Order Order { get; set; }
        public SubProduct subproduct { get; set; }
        

    }
}
