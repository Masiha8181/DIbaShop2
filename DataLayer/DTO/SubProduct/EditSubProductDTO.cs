using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.SubProduct
{
    public class EditSubProductDTO
    {
        public int id { get; set; }
        public int Productid { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "نام مدل محصول")]

        public string ProductModelName { get; set; }

        
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "قیمت مدل محصول")]
        public decimal Price { get; set; }

       
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "تعداد  مدل محصول")]
        public int Count { get; set; } = 1;

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "رنگ  مدل محصول")]
        public int Colorid { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "سایز  مدل محصول")]
        public int Sizeid { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "  موجود است؟")]
        public bool IsInStock { get; set; }

    }
}
