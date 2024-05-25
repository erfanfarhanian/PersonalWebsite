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
    public class EditSkillModel : PageModel
    {
        private IUserService _userService;
        public EditSkillModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Skill Skill { get; set; }

        public void OnGet(int id)
        {
            Skill = _userService.GetSkillById(id);
        }

        public IActionResult OnPost(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.UpdateSkill(skill);

            return RedirectToPage("Index");
        }
    }
}