using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.Category
{
    public class ModifyCategoryProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(100)]
        public string categoryName { get; set; }
        [Display(Name = "فایل عکس")]


        public string? ImageAddress { get; set; }
        [Display(Name = "زیر دسته بندی")]
        public int? Parentid { get; set; }
    }
}
