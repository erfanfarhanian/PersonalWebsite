using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Web.ViewComponents
{
    public class BlogsComponent :ViewComponent
    {
        private IBlogService _BlogService;

        public BlogsComponent(IBlogService blogService)
        {
            _BlogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/BlogsComponent.cshtml", _BlogService.GetBlogList());
        }
    }
}
