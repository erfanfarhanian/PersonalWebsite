using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Context;
using PersonalWebsite.DataLayer.Entities.User;

namespace PersonalWebsite.Web.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        IUserService _userService;
        private PersonalWebsiteContext _context;
        public IndexModel(IUserService userService, PersonalWebsiteContext context)
        {
            _context = context;
            _userService = userService;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _userService.GetUsers();
        }
    }
}