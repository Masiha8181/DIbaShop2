using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Color
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]

        public string ColorValue { get; set; }
        public string ColorCode { get; set; }
        public List<SubProduct> SubProducts { get; set; }

    }
}
