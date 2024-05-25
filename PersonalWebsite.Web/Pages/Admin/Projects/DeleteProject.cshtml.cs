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
    public class DeleteProjectModel : PageModel
    {
        private IUserService _userService;
        public DeleteProjectModel(IUserService userService)
        {
            _userService = userService;
        }

        public ShowProjectsForAdminViewModel ShowProjectsForAdminViewModel { get; set; }

        public void OnGet(int id)
        {
            ViewData["projectId"] = id;
            ShowProjectsForAdminViewModel = _userService.GetProjectInformation(id);
        }

        public IActionResult OnPost(int projectId)
        {
            _userService.DeletProject(projectId);
            return RedirectToPage("Index");
        }
    }
}