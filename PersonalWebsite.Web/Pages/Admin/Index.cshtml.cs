using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private IBlogService _blogService;
        private IUserService _userService;
        public IndexModel(IBlogService blogService, IUserService userService)
        {
            _blogService = blogService;
            _userService = userService;
        }

        public Tuple<List<PersonalWebsite.DataLayer.Entities.User.Contact>, int> Contacts { get; set; }
        public List<PersonalWebsite.DataLayer.Entities.User.AboutUser> AboutUser { get; set; }
        public void OnGet(int pageId = 1)
        {
            ViewData["BlogCount"] = _blogService.GetBlogCount();
            ViewData["ContactCount"] = _userService.GetContactCount();
            ViewData["CommentCount"] = _blogService.GetCommentCount();

            Contacts = _userService.GetContactForAdmin(pageId, 10);
            AboutUser = _userService.GetAboutUsersForAdmin();
        }
    }
}