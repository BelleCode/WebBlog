using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBlog.Data;
using WebBlog.Models;
using WebBlog.Services;
using WebBlog.Services.Iterfaces;
using X.PagedList;

namespace WebBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISlugService _slugService;
        private readonly IImageService _imageService;
        private readonly SearchService _searchService;

        public PostsController(ApplicationDbContext context, ISlugService slugService, IImageService imageService, SearchService searchService)
        {
            _context = context;
            _slugService = slugService;
            _imageService = imageService;
            _searchService = searchService;
        }

        private Blog f(Post p)
        {
            return p.Blog;
        }

        // GET: Posts
        public async Task<IActionResult> GetPostsWithTags(string text)
        {
            // Get Posts with a specific tag
            var getPostsWithTags = _context.Posts.Where(p => p.Tags.Any(t => t.Text == text));
            return View("Index", getPostsWithTags);
        }

        // GET: Posts/Details/Blog Posts Index
        public async Task<IActionResult> BlogPostIndex(int? blogId)
        {
            if (blogId == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Where(p => p.BlogId == blogId && p.ReadyStatus == Enums.ReadyStatus.ProductionReady)
                .ToListAsync();

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts
        public async Task<IActionResult> PostIndex(int? blogId)
        {
            var productionReadyPosts = await _context.Posts
                .Where(p => p.BlogId == blogId && p.ReadyStatus == Enums.ReadyStatus.ProductionReady)
                .ToListAsync();

            return View(productionReadyPosts);
        }

        public async Task<IActionResult> SearchIndexAsync(int? page, string searchTerm)
        {
            ViewData["SearchTerm"] = searchTerm;

            var pageNumber = page ?? 1;
            var pageSize = 5;

            var posts = _context.Posts.Where(p => p.ReadyStatus == Enums.ReadyStatus.ProductionReady).AsQueryable();

            if (searchTerm != null)
            {
                //Make the search string lowercase
                searchTerm = searchTerm.ToLower();

                posts = posts.Where(p =>
                   p.Title.ToLower().Contains(searchTerm) ||
                   p.Abstract.ToLower().Contains(searchTerm) ||
                   p.Content.ToLower().Contains(searchTerm) ||
                   p.Comments.Any(c => c.Body.ToLower().Contains(searchTerm) ||
                                       c.ModeratedBody.ToLower().Contains(searchTerm) ||
                                       c.BlogUser.FirstName.ToLower().Contains(searchTerm) ||
                                       c.BlogUser.LastName.ToLower().Contains(searchTerm) ||
                                       c.BlogUser.Email.ToLower().Contains(searchTerm)));
            }

            posts = posts.OrderByDescending(p => p.Created);
            return View(await posts.ToPagedListAsync(pageNumber, pageSize));
        }

        // Only show posts that ADMIN has access to
        public async Task<IActionResult> PostsIndexAdmin()
        {
            var applicationDbContext = _context.Posts.Include(p => p.Blog);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> PostDetails(string slug)
        {
            // check if null or empty
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Blog)
                .Include(p => p.Comments.Where(p => p.Deleted == null))
                .ThenInclude(c => c.BlogUser)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.Slug == slug);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Name");
            ViewData["BlogUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Title,Abstract,Content,ReadyStatus,Image")] Post post, List<string> TagValues)
        {
            if (ModelState.IsValid)
            {
                // post.Created = DateTime.Now;
                // post.ImageData = await _imageService.EncodeImageAsync(post.Image);
                // post.ImageType = _imageService.ContentType(post.Image);

                //Create the slug and determine if it is unique
                var slug = _slugService.UrlFriendly(post.Title);

                if (!_slugService.SlugIsUnique(slug))
                {
                    ModelState.AddModelError("Title", "The Title you have provided cannot be used as it results in a duplicate slug.");
                    //Add a Model State error and return the user back to the Create View
                    ModelState.AddModelError("", "There was an error related to the title...");
                    ViewData["BLogId"] = new SelectList(_context.Blogs, "Id", "Description", post.BlogId);
                    ViewData["TagValues"] = string.Join(",", TagValues);
                    return View(post);
                }

                post.Slug = slug;
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Description", post.BlogId);

            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Name", post.BlogId);

            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Created, BlogId,Title,Abstract,Content, Image, ImageType, ImageData, Slug")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    post.Updated = DateTime.Now;
                    var newImageData = await _imageService.EncodeImageAsync(post.Image);
                    var newSlug = _slugService.UrlFriendly(post.Title);

                    if (newSlug != post.Slug)
                    {
                        if (_slugService.SlugIsUnique(newSlug))
                        {
                            post.Slug = newSlug;
                        }
                        else
                        {
                            //I have determined that the Title results in a duplicate Slug...
                            ModelState.AddModelError("Title", "The Title you entered cannot be used please try again");
                            ModelState.AddModelError("", "There was an error related to the Title...");
                            //ViewData["TagValues"] = string.Join(",", TagValues);
                            ViewData["BlogId"] = new SelectList(_context.Blogs, "Id", "Name", post.BlogId);
                            return View(post);
                        }
                    }

                    if (post.ImageData != newImageData && post.Image != null)
                    {
                        post.ImageType = _imageService.ContentType(post.Image);
                        post.ImageData = newImageData;
                    }
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}