using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataLayer.DTO.Product
{
    public class CreateProductDTO
    {

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Display(Name = "توضیحات محصول")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        
        public string ProductDescription { get; set; }

        [Display(Name = "توضیحات کوتاه محصول")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string ShortProductDescription { get; set; }
        [Display(Name = "قیمت پایه محصول به تومان")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
     
        public double Price { get; set; }

        [Display(Name = "عکس اصلی محصول")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public IFormFile MainProductImage { get; set; }
        [Display(Name = "محصول موجود است؟")]
        public bool IsInStock { get; set; }

        [Display(Name = "دسته بندی محصول")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public int CategoryProductid { get; set; }


    }
}
