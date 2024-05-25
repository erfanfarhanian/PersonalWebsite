using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Core.DTOs.Blog
{
    public class ShowBlogListItemViewModel
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string SDescription { get; set; }
        public string BlogImageName { get; set; }
    }
}
