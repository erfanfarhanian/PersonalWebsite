using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.User;

namespace PersonalWebsite.Web.Controllers
{
    public class ContactController : Controller
    {
        private IUserService _userService;
        public ContactController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            contact.CreateDate = DateTime.Now;
            _userService.AddContact(contact);

            if (contact != null)
            {
                ViewBag.SuccessMessage = true;
            }

            return Redirect("/");
        }
    }
}