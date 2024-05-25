using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Core.DTOs.Blog
{
    public class SearchBlogForAdminViewModel
    {
        public List<PersonalWebsite.DataLayer.Entities.Weblog.Blog> Blogs { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
