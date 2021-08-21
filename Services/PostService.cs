using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlog.Data;
using WebBlog.Models;
using WebBlog.Enums;
using Microsoft.EntityFrameworkCore;

namespace CSharp___WebBlog.Services
{
    public class PostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts
                .Where(p => p.ReadyStatus == ReadyStatus.ProductionReady)
                .OrderByDescending(p => p.Created)
                .Include(b => b.Blog)
                .ToListAsync();
        }
    }
}