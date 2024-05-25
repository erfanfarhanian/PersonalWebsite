using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalWebsite.DataLayer.Entities.Weblog
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public int BlogId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(700, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string UserComment { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }

        public bool IsAdminRead { get; set; }


        public Blog Blog { get; set; }
    }
}
