using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order
    {
        public enum StatusCode
        {
            Payed = 0,
            Recived =1,
            Prepering=2,
            SendToPost=3,
            Finished=4,
            Failed=5
        }
        [Key] public int id { get; set; }
     
        public DateTime CreateDate { get; set; }
        public double TotalPrice { get; set; }
        public double? TotalDiscount{ get; set; }
        public bool IsFinaly { get; set; }
        public StatusCode Status { get; set; }
        public User User { get; set; }
        public List<Cart> Carts { get; set; }


    }
}
