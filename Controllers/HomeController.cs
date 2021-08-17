using WebBlog.Models;
using WebBlog.Services.Iterfaces;
using WebBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using WebBlog.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using X.PagedList;

namespace WebBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IBlogEmailSender emailSender, ApplicationDbContext context)
        {
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;

            //var blogs = _context.Blogs.Where
            //    (b => b.Posts.Any
            //    (p => p.ReadyStatus == Enums.ReadyStatus.ProductionReady))
            //    .OrderByDescending(b => b.Created)
            //    .ToPagedListAsync(pageNumber, pageSize);

            //return view(await blogs);

            var productionReadyPosts = _context.Blogs.Where(b => b.Posts.Any(p => p.ReadyStatus == Enums.ReadyStatus.ProductionReady));
            var orderedPosts = productionReadyPosts.OrderByDescending(b => b.Created).ToPagedListAsync(pageNumber, pageSize);

            return View(await orderedPosts);
            //return View(await _context.Blogs.Include(p => p.Posts).ToListAsync());
        }

        private object OrderByDescending(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([Bind("Name, Email, Phone, Subject, Message")] ContactMe model)
        {
            // This is where te email will be sent
            model.Message = $"{model.Message} <hr/> Phone : {model.Phone}";
            await _emailSender.SendContactEmailAsync(model.Email, model.Name, model.Subject, model.Message);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}