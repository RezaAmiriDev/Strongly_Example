using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ClassLibrary
{
    public class PageComment
    {
        [Key]
        public int CommentId { get; set; }

        [Display(Name="خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PageId {  get; set; }

        [Display(Name = "نام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "وب سایت")]
        public string WebSite { get; set; }

        [Display(Name = " نظرات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Comment {  get; set; }

        [Display(Name = "تاریخ ایجاد ")]
        public DateTime CreateDate { get; set; }

  
        public virtual Page page { get; set; }

        public PageComment() { }


    }
}
