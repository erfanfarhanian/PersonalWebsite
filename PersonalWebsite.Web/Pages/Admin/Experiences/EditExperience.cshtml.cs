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
    public class EditExperienceModel : PageModel
    {
        private IUserService _userService;
        public EditExperienceModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Experience Experience { get; set; }

        public void OnGet(int id)
        {
            Experience = _userService.GetExperienceById(id);
        }

        public IActionResult OnPost(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.UpdateExperience(experience);

            return RedirectToPage("Index");
        }
    }
}