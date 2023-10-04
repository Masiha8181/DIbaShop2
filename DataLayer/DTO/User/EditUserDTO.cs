using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.User
{
    public class EditUserDTO
    {
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل معتبر نیست")]
        [Display(Name = "ایمیل")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(100)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(100)]
        [Compare("Password", ErrorMessage = "مقادیر یکی نیستند")]
        public string ConfirmPassword { get; set; }
      




        [Display(Name = "آیا ادمین باشد؟")]
        public bool IsAdmin { get; set; }
        [Display(Name = "فعال کردن کاربر")]
        public bool IsActive { get; set; }
    }
}
