using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;

namespace PersonalWebsite.Web.Pages.Admin.Projects
{
    public class EditProjectModel : PageModel
    {
        private IUserService _userService;
        public EditProjectModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Project Project { get; set; }

        public void OnGet(int id)
        {
            Project = _userService.GetProjectById(id);
        }

        public IActionResult OnPost(Project project, IFormFile imgProjectUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.UpdateProject(project, imgProjectUp);

            return RedirectToPage("Index");
        }
    }
}