using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.DataLayer.Entities.Weblog;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin.Blogs
{
    public class AddContentModel : PageModel
    {
        private IBlogService _blogService;
        public AddContentModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost(IFormFile imgContentUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _blogService.AddContent(Blog, imgContentUp);

            return RedirectToPage("Index");
        }
    }
}