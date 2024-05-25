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
    public class DeleteSkillModel : PageModel
    {
        private IUserService _userService;
        public DeleteSkillModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Skill Skill { get; set; }

        public void OnGet(int id)
        {
            ViewData["skillId"] = id;
            Skill = _userService.GetSkillInformation(id);
        }

        public IActionResult OnPost(int skillId)
        {
            _userService.DeleteSkill(skillId);

            return RedirectToPage("Index");
        }
    }
}