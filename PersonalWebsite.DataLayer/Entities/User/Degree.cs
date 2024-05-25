using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalWebsite.DataLayer.Entities.User
{
    public class Degree
    {
        [Key]
        public int DegreeId { get; set; }

        [Display(Name = "عنوان مدرک")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Title { get; set; }

        [Display(Name = "نام موسسه")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Academy { get; set; }

        [Display(Name = "تاریخ دریافت مدرک")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ReceivedDate { get; set; }

    }
}
