using Microsoft.AspNetCore.Http;
using PersonalWebsite.Core.DTOs.Blog;
using PersonalWebsite.DataLayer.Entities.Weblog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace PersonalWebsite.Core.Services.Interfaces
{
    public interface IBlogService
    {
        #region Blog

        int AddContent(Blog blog, IFormFile imgContent);

        List<ShowBlogForAdminViewModel> GetBlogsForAdmin();

        SearchBlogForAdminViewModel GetFilteredBlog(int pageId = 1, string title = "");

        Blog GetBlogById(int blogId);

        ShowBlogForAdminViewModel GetBlogInformation(int blogId);

        void UpdateBlog(Blog blog, IFormFile imgContent);

        void DeletContent(int blogId);

        Tuple<List<ShowBlogListItemViewModel>, int> GetBlogList(int pageId = 1, int take = 0, string search = "");

        Blog GetBlogForShow(int blogId);

        int GetBlogCount(); 
        #endregion

        #region Comment

        void AddComment(Comment comment);

        Tuple<List<Comment>, int> GetBlogComment(int blogId, int pageId = 1);

        Tuple<List<SearchCommentForAdminViewModel>, int> GetFilteredComment(int pageId = 1, int take = 0, string search = "");

        Comment GetCommentById(int commentId);

        ShowCommentForAdminViewModel GetCommentInformation(int commentId);

        void DeleteComment(int commentId);

        void UpdateComment(Comment comment);

        int GetCommentCount();
        #endregion
    }
}
