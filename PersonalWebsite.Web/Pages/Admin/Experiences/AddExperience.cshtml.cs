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
    public class AddExperienceModel : PageModel
    {
        private IUserService _userService;
        public AddExperienceModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Experience Experience { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.AddExperience(Experience);

            return RedirectToPage("Index");
        }
    }
}