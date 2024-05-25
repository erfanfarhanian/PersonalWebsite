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
    public class DeleteDegreeModel : PageModel
    {
        private IUserService _userService;
        public DeleteDegreeModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Degree Degree { get; set; }

        public void OnGet(int id)
        {
            ViewData["degreeId"] = id;
            Degree = _userService.GetDegreeInformation(id);
        }

        public IActionResult OnPost(int degreeId)
        {
            _userService.DeleteDegree(degreeId);

            return RedirectToPage("Index");
        }
    }
}