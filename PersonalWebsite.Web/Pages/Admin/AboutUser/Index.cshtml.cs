using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Context;

namespace PersonalWebsite.Web.Pages.Admin.AboutUser
{
    public class IndexModel : PageModel
    {
        IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<PersonalWebsite.DataLayer.Entities.User.AboutUser> AboutUser { get; set; }

        public void OnGet()
        {
            AboutUser = _userService.GetAboutUsersForAdmin();
        }
    }
}