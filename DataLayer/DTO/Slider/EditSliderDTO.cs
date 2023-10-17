﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataLayer.DTO.Slider
{
    public class EditSliderDTO
    {

        public int id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [Display(Name = "نام اسلایدر")]
        public string SliderName { get; set; }
        
        public string? SliderImageAddress { get; set; }


        [Display(Name = "لینک اختیاری سایت ")]
        public string? PageAddress { get; set; }
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [Display(Name = "ایا فعال باشد؟")]
        public bool IsActive { get; set; }
    }
}
