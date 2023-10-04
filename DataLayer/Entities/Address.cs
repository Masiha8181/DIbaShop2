using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Address
    {
        [Key]
        [Required]
        public int id { get; set; }
        public  int Userid { get; set; }
        [MaxLength(50)]
        [Required]
        public string AddressName { get; set; }
        [MaxLength(50)]
        [Required]
        public string ReciverFirstName { get; set; }
        [MaxLength(100)]
        [Required]
        public string ReciverLastName { get; set; }
        [MaxLength(20)]
        [Required]
        public string ReciverPhoneNumber { get; set; }
        [MaxLength(50)]
        [Required]
        public string Province { get; set; }
        [MaxLength(50)]
        [Required]
        public string City { get; set; }
        [MaxLength(20)]
        [Required]
        public int PostCode { get; set; }
        
        [Required]
        public string FullAddress { get; set; }
        [MaxLength(20)]
        [Required]
        public int Number { get; set; }
        [MaxLength(20)]
        [Required]
        public int Unit { get; set; }
        public User User { get; set; }

    }
}
