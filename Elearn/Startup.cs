using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Elearn.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Elearn.Models;
using Rotativa.AspNetCore;
using Newtonsoft.Json;
using Elearn.MailHelp;

namespace Elearn
{
    public class Startup
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddHostedService<MailService>();

            CreateRoles();
        }

        // Creates roles in DB if not exists, roles are in appsettings.json
        public void CreateRoles()
        {

            List<AspNetRoles> roles = context.AspNetRoles.ToList();
            var obj = Configuration.GetSection("Roles");
            var rolesArr = obj.Get<string[]>();

            for (int i = 0; i < rolesArr.Length; i++)
            {
                if (roles.Where(x => x.Name == rolesArr[i]).ToList().Count() == 0)
                {
                    AspNetRoles role = new AspNetRoles();
                    role.Name = rolesArr[i];
                    role.NormalizedName = rolesArr[i].ToUpper();
                    role.ConcurrencyStamp = Guid.NewGuid().ToString();
                    role.Id = Guid.NewGuid().ToString();
                    context.Add(role);

                }
            }
            context.SaveChanges();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");
        }
    }
}
