using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class AdminLogIN
    {
        [Key]
        public int LoginId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید")]
        [MaxLength(200)]
        public string? UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید")]
        [MaxLength(200)]
        public string? Email { get; set; }
        [Display(Name ="رمز عبور")]
        [Required(ErrorMessage ="لطفا {0}را وارد کنید")]
        [MaxLength(200)]
        public string? Password { get; set; }
    }
}
