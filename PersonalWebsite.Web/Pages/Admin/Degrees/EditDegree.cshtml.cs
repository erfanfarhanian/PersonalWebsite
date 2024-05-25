using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;

namespace PersonalWebsite.Web.Pages.Admin.Degrees
{
    public class EditDegreeModel : PageModel
    {
        private IUserService _userService;
        public EditDegreeModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Degree Degree { get; set; }

        public void OnGet(int id)
        {
            Degree = _userService.GetDegreeById(id);
        }

        public IActionResult OnPost(Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.UpdateDegree(degree);

            return RedirectToPage("Index");
        }
    }
}