using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.SubProduct
{
    public class CreateDiscountDTO
    {
        public Entities.SubProduct SubProduct { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "درصد تخفیف")]
        public int? DiscountPercent { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "تاریخ شروع تخفیف")]
        public DateTime? DiscountStart { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "تاریخ پایان تخفیف")]
        public DateTime? DiscountEnd { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "فعال باشد؟")]
        public bool IsHaveActiveDIscount { get; set; }
    }
}
