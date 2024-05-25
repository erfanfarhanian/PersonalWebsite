using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.DTOs.Blog;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.Weblog;

namespace PersonalWebsite.Web.Pages.Admin.Blogs
{
    public class DeleteContentModel : PageModel
    {
        private IBlogService _blogService;
        public DeleteContentModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public ShowBlogForAdminViewModel ShowBlogForAdminViewModel { get; set; }

        public void OnGet(int id)
        {
            ViewData["blogId"] = id;
            ShowBlogForAdminViewModel = _blogService.GetBlogInformation(id);
        }

        public IActionResult OnPost(int blogId)
        {
            _blogService.DeletContent(blogId);
            return RedirectToPage("Index");
        }
    }
}