using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.DTOs.Blog;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin.Comments
{
    public class IndexModel : PageModel
    {
        private IBlogService _blogService;
        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public Tuple<List<SearchCommentForAdminViewModel>, int> SearchCommentForAdminViewModel { get; set; }

        public void OnGet(int pageId = 1, string filterTitle = "")
        {
            SearchCommentForAdminViewModel = _blogService.GetFilteredComment(pageId, 10 ,filterTitle);
        }
    }
}