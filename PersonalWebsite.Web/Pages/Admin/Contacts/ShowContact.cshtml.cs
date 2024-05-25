using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;

namespace PersonalWebsite.Web.Pages.Admin.Contacts
{
    public class ShowContactModel : PageModel
    {
        private IUserService _userService;
        public ShowContactModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public void OnGet(int id)
        {
            ViewData["contactId"] = id;
            Contact = _userService.GetContactById(id);
        }

        public IActionResult OnPost(int contactId)
        {
            _userService.DeleteContact(contactId);
            return RedirectToPage("Index");
        }
    }
}