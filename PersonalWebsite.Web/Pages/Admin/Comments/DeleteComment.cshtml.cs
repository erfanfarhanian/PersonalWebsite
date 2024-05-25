using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.DTOs.Blog;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin.Comments
{
    public class DeleteCommentModel : PageModel
    {
        private IBlogService _blogService;
        public DeleteCommentModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public ShowCommentForAdminViewModel ShowCommentForAdminViewModel = new ShowCommentForAdminViewModel();

        public void OnGet(int id)
        {
            ViewData["commentId"] = id;
            ShowCommentForAdminViewModel = _blogService.GetCommentInformation(id);
        }

        public IActionResult OnPost(int commentId)
        {
            _blogService.DeleteComment(commentId);
            return RedirectToPage("Index");
        }
    }
}