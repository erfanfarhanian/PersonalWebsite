﻿using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Web.ViewComponents
{
    public class ExperienceComponent : ViewComponent
    {
        private IUserService _userService;

        public ExperienceComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ExperienceComponent.cshtml", _userService.GetExperiencesForAdmin());
        }
    }
}
