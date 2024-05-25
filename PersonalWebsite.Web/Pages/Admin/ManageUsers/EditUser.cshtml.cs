using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.DTOs;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin.ManageUsers
{
    public class EditUserModel : PageModel
    {
        private IUserService _userService;
        public EditUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public EditUserViewModel EditUserViewModel { get; set; }

        public void OnGet(int id)
        {
            EditUserViewModel = _userService.GetUserForShowInEditMode(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.EditUserFromAdmin(EditUserViewModel);
            return RedirectToPage("Index");
        }
    }
}