using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;

namespace PersonalWebsite.Web.Pages.Admin.Educations
{
    public class EditEducationModel : PageModel
    {
        private IUserService _userService;
        public EditEducationModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Education Education { get; set; }

        public void OnGet(int id)
        {
            Education = _userService.GetEducationById(id);
        }

        public IActionResult OnPost(Education education)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.UpdateEducation(education);

            return RedirectToPage("Index");
        }
    }
}