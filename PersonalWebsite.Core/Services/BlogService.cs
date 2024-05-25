using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Core.Convertors;
using PersonalWebsite.Core.DTOs.Blog;
using PersonalWebsite.Core.Generator;
using PersonalWebsite.Core.Secutiry;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Context;
using PersonalWebsite.DataLayer.Entities.User;
using PersonalWebsite.DataLayer.Entities.Weblog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PersonalWebsite.Core.Services
{
    public class BlogService : IBlogService
    {
        private PersonalWebsiteContext _context;

        public BlogService(PersonalWebsiteContext context)
        {
            _context = context;
        }

        public int AddContent(Blog blog, IFormFile imgContent)
        {
            blog.CreateDate = DateTime.Now;
            blog.BlogImageName = "no-photo.jpg";

            //TODO Check Image
            if (imgContent != null && imgContent.IsImage())
            {
                blog.BlogImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgContent.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blog/image", blog.BlogImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgContent.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blog/thumb", blog.BlogImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 500);
            }

            _context.Add(blog);
            _context.SaveChanges();

            return blog.BlogId;
        }

        public void DeletContent(int blogId)
        {
            Blog blog = GetBlogById(blogId);
            if (blog.BlogImageName != "no-photo.jpg")
            {
                string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blog/image", blog.BlogImageName);
                if (File.Exists(deleteimagePath))
                {
                    File.Delete(deleteimagePath);
                }

                string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blog/thumb", blog.BlogImageName);
                if (File.Exists(deletethumbPath))
                {
                    File.Delete(deletethumbPath);
                }
            }
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }

        public Blog GetBlogById(int blogId)
        {
            return _context.Blogs.Find(blogId);
        }

        public ShowBlogForAdminViewModel GetBlogInformation(int blogId)
        {
            var blog = GetBlogById(blogId);
            ShowBlogForAdminViewModel blogContent = new ShowBlogForAdminViewModel();
            blogContent.Title = blog.Title;
            blogContent.CreateDate = blog.CreateDate;
            blogContent.SDescription = blog.SDescription;
            blogContent.BlogImageName = blog.BlogImageName;

            return blogContent;
        }

        public List<ShowBlogForAdminViewModel> GetBlogsForAdmin()
        {
            return _context.Blogs.Select(b => new ShowBlogForAdminViewModel()
            {
                BlogId = b.BlogId,
                BlogImageName = b.BlogImageName,
                Title = b.Title,
                SDescription = b.SDescription,
                CreateDate = b.CreateDate
            }).ToList();
        }

        public SearchBlogForAdminViewModel GetFilteredBlog(int pageId = 1, string title = "")
        {
            IQueryable<Blog> result = _context.Blogs;

            if (!string.IsNullOrEmpty(title))
            {
                result = result.Where(b => b.Title.Contains(title));
            }

            // Show Item In Page
            int take = 10;
            int skip = (pageId - 1) * take;

            SearchBlogForAdminViewModel list = new SearchBlogForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            if ((list.PageCount % 2) != 0)
            {
                list.PageCount += 1;
            }

            list.Blogs = result.OrderBy(b => b.CreateDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public Tuple<List<ShowBlogListItemViewModel>, int> GetBlogList(int pageId = 1, int take = 0, string filter = "")
        {
            if (take == 0)
            {
                take = 6;
            }

            IQueryable<Blog> result = _context.Blogs;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(b => b.Title.Contains(filter));
            }

            int skip = (pageId - 1) * take;

            int pageCount = result.Select(b => new ShowBlogListItemViewModel()
            {
                BlogId = b.BlogId,
                Title = b.Title,
                CreateDate = b.CreateDate,
                SDescription = b.SDescription,
                BlogImageName = b.BlogImageName
            }).OrderByDescending(b => b.BlogId).Count() / take;
            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Select(b => new ShowBlogListItemViewModel()
            {
                BlogId = b.BlogId,
                Title = b.Title,
                CreateDate = b.CreateDate,
                SDescription = b.SDescription,
                BlogImageName = b.BlogImageName
            }).OrderByDescending(b => b.BlogId).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public void UpdateBlog(Blog blog, IFormFile imgContent)
        {
            blog.CreateDate = DateTime.Now;
            if (imgContent != null && imgContent.IsImage())
            {
                if (blog.BlogImageName != "no-photo.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blog/image", blog.BlogImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blog/thumb", blog.BlogImageName);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }
                blog.BlogImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgContent.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blog/image", blog.BlogImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgContent.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blog/thumb", blog.BlogImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 250);
            }

            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }

        public Blog GetBlogForShow(int blogId)
        {
            return _context.Blogs.FirstOrDefault(b => b.BlogId == blogId);
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public Tuple<List<Comment>, int> GetBlogComment(int blogId, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            int pageCount = _context.Comments.Where(c => !c.IsDelete && c.IsAdminRead && c.BlogId == blogId).Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            return Tuple.Create(_context.Comments.Where(c => !c.IsDelete && c.IsAdminRead && c.BlogId == blogId).Skip(skip).Take(take)
                                .OrderByDescending(c => c.CreateDate).ToList(), pageCount);
        }

        public Tuple<List<SearchCommentForAdminViewModel>, int> GetFilteredComment(int pageId = 1, int take = 0, string search = "")
        {
            if (take == 0)
            {
                take = 10;
            }

            IQueryable<Comment> result = _context.Comments;

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(b => b.Blog.Title.Contains(search));
            }

            int skip = (pageId - 1) * take;

            int pageCount = result.Select(c => new SearchCommentForAdminViewModel()
            {
                CommentId = c.CommentId,
                BlogId = c.BlogId,
                Title = c.Blog.Title,
                CreateDate = c.CreateDate,
                UserComment = c.UserComment,
                UserName = c.UserName,
                IsAdminRead = c.IsAdminRead
            }).OrderByDescending(c => c.CreateDate).Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Select(c => new SearchCommentForAdminViewModel()
            {
                CommentId = c.CommentId,
                BlogId = c.BlogId,
                Title = c.Blog.Title,
                CreateDate = c.CreateDate,
                UserComment = c.UserComment,
                UserName = c.UserName,
                IsAdminRead = c.IsAdminRead
            }).OrderByDescending(c => c.CreateDate).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public ShowCommentForAdminViewModel GetCommentInformation(int commentId)
        {
            var comment = GetCommentById(commentId);

            ShowCommentForAdminViewModel commentInfo = new ShowCommentForAdminViewModel();
            commentInfo.CreateDate = comment.CreateDate;
            commentInfo.UserName = comment.UserName;
            commentInfo.UserComment = comment.UserComment;

            return commentInfo;
        }

        public Comment GetCommentById(int commentId)
        {
            return _context.Comments.Find(commentId);
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = GetCommentById(commentId);

            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            comment.IsAdminRead = !comment.IsAdminRead;
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public int GetCommentCount()
        {
            return _context.Comments.Count();
        }
    }
}
