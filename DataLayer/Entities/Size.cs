using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Size
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]

        public string SizeValue { get; set; }
        public List<SubProduct> SubProducts { get; set; }
    }
}
