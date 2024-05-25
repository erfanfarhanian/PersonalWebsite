using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalWebsite.DataLayer.Entities.User
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }

        [Display(Name = "نام شرکت")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Description { get; set; }

        [Display(Name = "از تاریخ")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string FromDate { get; set; }

        [Display(Name = "تا تاریخ")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string TillDate { get; set; }
    }
}
