using WebBlog.Data;
using WebBlog.Models;
using WebBlog.Services;
using WebBlog.Services.Iterfaces;
using WebBlog.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Connection.GetConnectionString(Configuration)));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<BlogUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddDefaultUI()
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //Register a preconfigured instance of the MailSettings Class
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IBlogEmailSender, EmailService>();

            // Register the Basic Slug Service class as a service
            services.AddTransient<BasicSeedService>();

            // Register the SeedService as a Transient
            services.AddScoped<BasicSeedService>();

            //Register the concrete Basic Image Service class to be used with the IImage Service Interface
            //If(I am in development)
            services.AddTransient<IImageService, BasicImageService>();
            //else
            //services.AddTransient<IImageService, AdvancedImageService>();

            //Register the Basic Slug Service
            services.AddScoped<ISlugService, BasicSlugService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
              {
                  // Allowing for Slug to be used instead in URL
                  endpoints.MapControllerRoute(
                      name: "SlugRoute",
                      pattern: "BlogPosts/UrlFriendly/{slug}",
                      defaults: new { controller = "Posts", action = "Details" });

                  endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller=Home}/{action=Index}/{id?}");
                  endpoints.MapRazorPages();
              });
        }
    }
}