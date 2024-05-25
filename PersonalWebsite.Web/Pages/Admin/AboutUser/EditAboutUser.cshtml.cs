using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin.AboutUser
{
    public class EditAboutUserModel : PageModel
    {
        private IUserService _userService;
        public EditAboutUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public PersonalWebsite.DataLayer.Entities.User.AboutUser AboutUser { get; set; }

        public void OnGet(int id)
        {
            AboutUser = _userService.GetAboutUserById(id);
        }

        public IActionResult OnPost(PersonalWebsite.DataLayer.Entities.User.AboutUser aboutUser, IFormFile imgUserProfileUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.UpdateAboutUser(aboutUser, imgUserProfileUp);

            return RedirectToPage("Index");
        }
    }
}