using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;
using Project = PersonalWebsite.DataLayer.Entities.User.Project;

namespace PersonalWebsite.Web.Pages.Admin.Projects
{
    public class AddProjectModel : PageModel
    {
        private IUserService _userService;
        public AddProjectModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Project Project { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost(IFormFile imgProjectUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.AddProject(Project, imgProjectUp);

            return RedirectToPage("Index");
        }
    }
}