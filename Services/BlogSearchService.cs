using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlog.Data;
using WebBlog.Models;

namespace WebBlog.Services
{
    public class BlogSearchService
    {
        private readonly ApplicationDbContext _context;

        public BlogSearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Post> ContentSearch(string searchTerm)
        {
            var posts = _context.Posts.Where(p => p.ReadyStatus == Enums.ReadyStatus.ProductionReady);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                //Make the search string lowercase
                searchTerm = searchTerm.ToLower();

                posts = posts.Where(p =>
                   p.Title.ToLower().Contains(searchTerm) ||
                   p.Abstract.ToLower().Contains(searchTerm) ||
                   p.Content.ToLower().Contains(searchTerm) ||
                   p.Blog.Name.ToLower().Contains(searchTerm) ||
                   p.Blog.Description.ToLower().Contains(searchTerm) ||
                   p.Tags.Any(t => t.Text.ToLower().Contains(searchTerm)) ||
                   p.Comments.Any(c =>
                        c.Body.ToLower().Contains(searchTerm) ||
                        c.ModeratedBody.ToLower().Contains(searchTerm) ||
                        c.BlogUser.FirstName.ToLower().Contains(searchTerm) ||
                        c.BlogUser.LastName.ToLower().Contains(searchTerm) ||
                        c.BlogUser.Email.ToLower().Contains(searchTerm)));
            }
            return posts.OrderByDescending(p => p.Created);
        }
    }
}