using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlog.Data;
using WebBlog.Models;

namespace WebBlog.Services
{
    public class SearchService
    {
        private readonly ApplicationDbContext _context;

        public SearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Post> ContentSearch(string searchStr)
        {
            var posts = _context.Posts.Where(p => p.ReadyStatus == Enums.ReadyStatus.ProductionReady);

            if (!string.IsNullOrEmpty(searchStr))
            {
                //Make the search string lowercase
                searchStr = searchStr.ToLower();

                posts = posts.Where(p =>
                   p.Title.ToLower().Contains(searchStr) ||
                   p.Abstract.ToLower().Contains(searchStr) ||
                   p.Content.ToLower().Contains(searchStr) ||
                   p.Comments.Any(c =>
                        c.Body.ToLower().Contains(searchStr) ||
                        c.ModeratedBody.ToLower().Contains(searchStr) ||
                        c.BlogUser.FirstName.ToLower().Contains(searchStr) ||
                        c.BlogUser.LastName.ToLower().Contains(searchStr) ||
                        c.BlogUser.Email.ToLower().Contains(searchStr)));
            }
            return posts.OrderByDescending(p => p.Created);
        }
    }
}