using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission7Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            ///Enables our app to follow the MVC Model
            services.AddControllersWithViews();

            //Enables the use of the context file
            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);
            });

            //Enables the use of the repository method
            services.AddScoped<IBookstoreProjectRepository, EFBookstoreProjectRepository>();
            services.AddScoped<IPurchaseRepository, EFPurchaseRepository>();

            //Enables the use of Razor Pages
            services.AddRazorPages();

            //Enables webapp to keep track of session data
            services.AddDistributedMemoryCache();
            services.AddSession();

            //Causes the program to create a cart when the session begins
            services.AddScoped<Cart>(x => SessionCart.GetCart(x));

            //Provides access to the HttpContext if there is one
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //Allows the app to use the wwwroot files, endpoint routing, and session data
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            //Creates the endpoints
            app.UseEndpoints(endpoints =>
            {
                //Creates an endpoint for when the app receives both page info and category info
                endpoints.MapControllerRoute("categorypage",
                    "{bookCategory}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" });

                //Creates endpoint for when just page info is received
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 });


                //Creates endpoint for when just category data is received
                endpoints.MapControllerRoute("category",
                    "{bookCategory}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                //creates a default endpoint for when no additional parameters are passed
                endpoints.MapDefaultControllerRoute();


                //creates enpoint to be used when razor pages are requested. 
                endpoints.MapRazorPages();
            });
        }
    }
}
