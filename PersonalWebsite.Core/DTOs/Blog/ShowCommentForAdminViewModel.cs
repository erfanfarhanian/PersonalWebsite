using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Core.DTOs.Blog
{
    public class ShowCommentForAdminViewModel
    {
        public int CommentId { get; set; }
        public string BlogTitle { get; set; }
        public string UserName { get; set; }
        public string UserComment { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsAdminRead { get; set; }
    }
}
