using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;

namespace PersonalWebsite.Web.Pages.Admin.Skills
{
    public class AddSkillModel : PageModel
    {
        private IUserService _userService;
        public AddSkillModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Skill Skill { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.AddSkill(Skill);

            return RedirectToPage("Index");
        }
    }
}