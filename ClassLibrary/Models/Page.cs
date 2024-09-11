using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Display(Name = "کروه صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupId { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string ShortDiscreption { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Text { get; set; }

        [Display(Name = "بازدید")]
        public int visite { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString ="{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = " کلمات کلیدی")]
        public string Tags { get; set; }
        public virtual GroupPage PageGroup { get; set; }
        public virtual List<PageComment> PageComments { get; set; }
        public Page() { }

    }
}
