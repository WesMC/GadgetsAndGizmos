using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using GadgetsAndGizmos.DataAccessLayer.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.DataAccessLayer.Repository;

namespace GadgetsAndGizmos
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            //Configuration = configuration;
            _env = env;

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //load base settings
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true) //load local settings
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true) //load environment settings
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /**
            * DB Context options below are different based on what OS you're using
            * 
            * WINDOWS = UseSqlServer
            * OSX = ?? (unknown currently)
            * LINUX = UseMySQL
            */
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            }

            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) 
            {
                /** Will need to figure out what this is on Mac for development */
                //services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(
                //    Configuration.GetConnectionString("DefaultConnection")));
            }

            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) 
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("MySQLConnection")));
            }
            // END OF DB CONTEXT OPTIONS BUILDER

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
