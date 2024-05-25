using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalWebsite.DataLayer.Entities.User
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        [Display(Name = "نام مهارت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }
        [Display(Name = "میزان مهارت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public Int16 Percent { get; set; }
    }
}
