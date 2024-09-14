using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyEshop.Data;
using MyEshop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyEshop
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            #region Db Context
            services.AddDbContext<MyEshopContext>(Option =>
            {
                Option.UseSqlServer("Data Source=MOHAMADREZA\\SOLTAN;Initial Catalog=EShopCore_DB; User Id=sa; Password=12345");
            });

            #endregion
            #region IoC
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddTransient<IGroupRepository, GroupRepository>();
            //services.AddSingleton<IGroupRepository, GroupRepository>();
            #endregion
            #region Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(Option =>
                {
                    Option.LoginPath = "/Account/Login";
                    Option.LogoutPath = "/Account/Logout";
                    Option.ExpireTimeSpan = TimeSpan.FromDays(10);
                });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/Admin"))
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.Redirect("/Account/Login");
                    }
                    else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
                    {
                        context.Response.Redirect("/Account/Login");
                    }
                   
                }
                    await next.Invoke();
                
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private static void myHandler(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
               

            });
        }
    }
}
