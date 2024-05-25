using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Web.ViewComponents
{
    public class AboutMeComponent : ViewComponent
    {
        private IUserService _userService;

        public AboutMeComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/AboutMeComponent.cshtml", _userService.GetAboutUsersForAdmin());
        }
    }
}
