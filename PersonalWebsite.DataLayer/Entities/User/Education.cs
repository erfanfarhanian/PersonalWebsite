using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalWebsite.DataLayer.Entities.User
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }

        [Display(Name = "عنوان مدرک")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Title { get; set; }

        [Display(Name = "موسسه یا دانشگاه")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string University { get; set; }

        [Display(Name = "رشته تحصیلی")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Major { get; set; }

        [Display(Name = "از تاریخ")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string FromDate { get; set; }

        [Display(Name = "تا تاریخ")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string TillDate { get; set; }
    }
}
