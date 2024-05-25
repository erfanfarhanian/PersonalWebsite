using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Pages.Admin.Contacts
{
    public class IndexModel : PageModel
    {
        private IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public Tuple<List<PersonalWebsite.DataLayer.Entities.User.Contact>, int> Contacts { get; set; }

        public void OnGet(int pageId = 1)
        {
            Contacts = _userService.GetContactForAdmin(pageId, 10);
        }
    }
}