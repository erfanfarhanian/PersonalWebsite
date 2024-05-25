using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.DTOs.Blog;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;
using PersonalWebsite.DataLayer.Entities.Weblog;

namespace PersonalWebsite.Web.Pages.Admin.Comments
{
    public class EditCommentModel : PageModel
    {
        private IBlogService _blogService;
        public EditCommentModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public Comment Comment { get; set; }

        public void OnGet(int id)
        {
            Comment = _blogService.GetCommentById(id);
        }

        public IActionResult OnPost(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _blogService.UpdateComment(comment);
            return RedirectToPage("Index");
        }
    }
}