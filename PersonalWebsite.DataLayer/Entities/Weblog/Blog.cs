using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalWebsite.DataLayer.Entities.Weblog
{
    public class Blog
    {
        public int BlogId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "متن کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string SDescription { get; set; }

        [Display(Name = "متن بلند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string LDescription { get; set; }

        [Display(Name = "تصویر مطلب")]
        [MaxLength(50)]
        public string BlogImageName { get; set; }

        #region Relation

        public List<Comment> Comments { get; set; }

        #endregion
    }
}
