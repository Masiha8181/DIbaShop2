using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Slider
    {

        [Key]
        [Required]
        public int id { get; set; }
        [MaxLength(50)]
        [Required]
        public string SliderName { get; set; }
        [MaxLength(200)]
        [Required]
        public string SliderImageAddress { get; set; }
        [MaxLength(200)]
       
        public string? PageAddress { get; set; }
        public bool IsActive { get; set; }
       
    }
}
