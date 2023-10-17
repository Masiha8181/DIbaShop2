using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.Size
{
    public class CreateSizeDto
    {
        [Display(Name = "سایز به عدد:")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        
        

        public int SizeValue { get; set; }

    }
}
