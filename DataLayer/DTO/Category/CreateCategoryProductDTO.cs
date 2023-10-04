using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataLayer.DTO.Category
{
    public class CreateCategoryProductDTO
    {
        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(100)]
        public string categoryName { get; set; }
        [Display(Name = "فایل عکس")]
      
      
        public IFormFile? ImageAddress { get; set; }
        [Display(Name = "زیر دسته بندی")]
        public int? Parentid { get; set; }
       

    }
}
