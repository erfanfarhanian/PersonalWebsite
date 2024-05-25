using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalWebsite.Core.DTOs.Blog
{
    public class ShowBlogForAdminViewModel
    {
        public int BlogId { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "متن کوتاه")]
        public string SDescription { get; set; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تصویر")]
        public string BlogImageName { get; set; }
    }
}
