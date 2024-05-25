using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Core.Services.Interfaces;

namespace PersonalWebsite.Web.Controllers
{
    public class ProjectController : Controller
    {
        private IUserService _userService;
        public ProjectController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int pageId = 1)
        {
            ViewBag.pageId = pageId;
            return View(_userService.GetProjectList(pageId, 16));
        }

        [Route("ShowProject/{id}")]
        public IActionResult ShowProject(int id)
        {
            var project = _userService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}