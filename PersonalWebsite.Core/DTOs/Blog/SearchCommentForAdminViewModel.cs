using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Core.DTOs.Blog
{
    public class SearchCommentForAdminViewModel
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserComment { get; set; }
        public bool IsAdminRead { get; set; }
    }
}
