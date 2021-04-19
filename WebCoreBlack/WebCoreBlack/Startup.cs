using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebCoreBlack.Model;

namespace WebCoreBlack
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        //This method gets called by the runtime.Use this method to add services to the container.
        //For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc();

            services.AddDbContextPool<AppDbContext>(
            options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddMvc(config => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
       

            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 1
                };

                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
             else
            {
                app.UseExceptionHandler("/Error");
                //app.UseStatusCodePages();
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                
            }

            //app.Use(async (context, next) =>
            //        {
            //            //await context.Response.WriteAsync(_config["Mykey"]);
            //            logger.LogInformation("MW1 received Incoming Request");
            //            //await context.Response.WriteAsync("Welcome to MiddleWare1");
            //            await next();
            //            logger.LogInformation("MW1 Sent Outgoing Response");
            //        }
            //        );
            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync(_config["Mykey"]);
            //    logger.LogInformation("MW2 received Incoming Request");
            //    //await context.Response.WriteAsync("Welcome to MiddleWare2");
            //    await next();
            //    logger.LogInformation("MW2 Sent Outgoing Response");
            //}
            //        );
            //app.Run(async (context) =>
            //        {
            //            //await context.Response.WriteAsync(_config["Mykey"]);
            //            await context.Response.WriteAsync("MW3 Request handled and Response sent back");
            //            logger.LogInformation("MW3 Request handled and Response sent back");
            //        }
            //      );

            //DefaultFilesOptions defaultfileoptions = new DefaultFilesOptions();
            //defaultfileoptions.DefaultFileNames.Clear();
            //defaultfileoptions.DefaultFileNames.Add("food.html");
            //app.UseDefaultFiles(defaultfileoptions);
            app.UseStaticFiles();
            app.UseAuthentication();
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("food.html");
            //app.UseFileServer(fileServerOptions);

            //app.UseFileServer();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(async (context) =>
            //        {
            //            // throw new Exception("Something unkown happended while processing request");
            //            //await context.Response.WriteAsync(_config["Mykey"]);
            //            await context.Response.WriteAsync("HelloWorld!");
            //            //logger.LogInformation("MW3 Request handled and Response sent back");
            //        }
            //      );
        }
    }
}
