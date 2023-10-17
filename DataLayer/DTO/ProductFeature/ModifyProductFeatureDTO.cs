using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.ProductFeature
{
    public class ModifyProductFeatureDTO
    {
        public int id { get; set; }
        public int Productid { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [Display(Name = "نام ویژگی محصول")]
        public string ProductInfoTitle { get; set; }
        [Display(Name = "مقدار ویژگی محصول")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string ProductInfoValue { get; set; }
    }
}
