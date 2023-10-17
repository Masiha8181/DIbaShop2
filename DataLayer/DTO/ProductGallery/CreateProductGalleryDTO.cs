using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataLayer.DTO.ProductGallery
{
    public class CreateProductGalleryDTO
    {
       

        public int Productid { get; set; }

        [Required(ErrorMessage = "فایلی انتخاب نشده است")]
        [Display(Name = "فایل تصویر محصول")]
        public IFormFile ImageAddress { get; set; }
       
    }
}

