using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ClassLibrary
{
    public class GroupPage
    {
        [Key]
        public int GroupId { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string GroupTitle { get; set; }


        public virtual List<Page> Pages { get; set; }

        public GroupPage(){}
        
    }
}
