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
    public class DeleteEducationModel : PageModel
    {
        private IUserService _userService;
        public DeleteEducationModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Education Education { get; set; }

        public void OnGet(int id)
        {
            ViewData["educationId"] = id;
            Education = _userService.GetEducationInformation(id);
        }

        public IActionResult OnPost(int educationId)
        {
            _userService.DeleteEducation(educationId);

            return RedirectToPage("Index");
        }
    }
}