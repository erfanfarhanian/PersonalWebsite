using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalWebsite.Core.DTOs.Resume
{
    public class ShowProjectsForAdminViewModel
    {
        public int ProjectID { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "تاریخ پروژه")]
        public string ProjectDate { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        public string SDescription { get; set; }

        [Display(Name = "تصویر")]
        public string ProjectImage { get; set; }

    }
}
