using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.Color
{
    public class CreateColorDTO
    {
    
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [Display(Name = "کد رنگ")]
        [MaxLength(50)]
        public string ColorCode { get; set; }
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [Display(Name = "نام رنگ")]
        [MaxLength(50)]
        public string ColorValue { get; set; }
    }
}
