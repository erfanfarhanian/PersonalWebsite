using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;

namespace PersonalWebsite.Web.Pages.Admin.Experiences
{
    public class IndexModel : PageModel
    {
        private IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<Experience> Experiences { get; set; }

        public void OnGet()
        {
            Experiences = _userService.GetExperiencesForAdmin();
        }
    }
}