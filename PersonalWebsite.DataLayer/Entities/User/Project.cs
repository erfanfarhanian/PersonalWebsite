using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalWebsite.DataLayer.Entities.User
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Title { get; set; }
        
        [Display(Name = "تاریخ پروژه")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ProjectDate { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string SDescription { get; set; }

        [Display(Name = "توضیحات بلند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string LDescription { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(50)]
        public string ProjectImage { get; set; }
    }
}
