using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.DTOs.Blog;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin.Blogs
{
    public class IndexModel : PageModel
    {
        private IBlogService _blogService;
        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        //public List<ShowBlogForAdminViewModel> BlogList { get; set; }
        public SearchBlogForAdminViewModel SearchBlogForAdminViewModel { get; set; }

        public void OnGet(int pageId = 1, string filterTitle = "")
        {
            //BlogList = _blogService.GetBlogsForAdmin();
            SearchBlogForAdminViewModel = _blogService.GetFilteredBlog(pageId, filterTitle);
        }
    }
}