using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.Weblog;

namespace PersonalWebsite.Web.Pages.Admin.Blogs
{
    public class EditContentModel : PageModel
    {
        private IBlogService _blogService;
        public EditContentModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public void OnGet(int id)
        {
            Blog = _blogService.GetBlogById(id);
        }

        public IActionResult OnPost(Blog blog, IFormFile imgContentUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _blogService.UpdateBlog(blog, imgContentUp);

            return RedirectToPage("Index");
        }
    }
}