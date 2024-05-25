using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.DTOs.Resume;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin.Projects
{
    public class IndexModel : PageModel
    {
        private IUserService _userservice;
        public IndexModel(IUserService userService)
        {
            _userservice = userService;
        }

        public List<ShowProjectsForAdminViewModel> ShowProjectsForAdminViewModel { get; set; }

        public void OnGet()
        {
            ShowProjectsForAdminViewModel = _userservice.GetProjectsForAdmin();
        }
    }
}