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
    public class DeleteExperienceModel : PageModel
    {
        private IUserService _userService;
        public DeleteExperienceModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Experience Experience { get; set; }

        public void OnGet(int id)
        {
            ViewData["experienceId"] = id;
            Experience = _userService.GetExperienceInformation(id);
        }

        public IActionResult OnPost(int experienceId)
        {
            _userService.DeleteExperience(experienceId);

            return RedirectToPage("Index");
        }
    }
}