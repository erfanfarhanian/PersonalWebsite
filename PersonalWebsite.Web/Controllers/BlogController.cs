using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Entities.Weblog;

namespace PersonalWebsite.Web.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index(int pageId = 1, string search = "")
        {
            ViewBag.pageId = pageId;
            return View(_blogService.GetBlogList(pageId, 8, search));
        }

        [Route("ShowBlog/{id}")]
        public IActionResult ShowBlog(int id)
        {
            var blog = _blogService.GetBlogForShow(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            comment.IsDelete = false;
            comment.IsAdminRead = false;
            comment.CreateDate = DateTime.Now;

            _blogService.AddComment(comment);
            return View("ShowComment", _blogService.GetBlogComment(comment.BlogId));
        }

        public IActionResult ShowComment(int id, int pageId = 1)
        {
            return View(_blogService.GetBlogComment(id, pageId));
        }
    }
}