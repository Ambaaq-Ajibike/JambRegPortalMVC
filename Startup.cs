using System;
using Microsoft.EntityFrameworkCore;
using JambRegistrationMVC.Interfaces.Services;
using JambRegistrationMVC.Implementations.Services;
using System.Collections.Generic;
using JambRegistrationMVC.Interfaces.Identity;
using JambRegistrationMVC.Context;
using Microsoft.AspNetCore.Http;
using JambRegistrationMVC.Interfaces.Repositories;
using JambRegistrationMVC.Implementations.Repositories;
using System.Linq;
using JambRegistrationMVC.Implementations.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JambRegistrationMVC
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
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICenterService, CenterService>();
            services.AddScoped<ICenterRepository, CenterRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<ISchoolCourseRepository, SchoolCourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IRoleRepository, RoleStore>();
            services.AddScoped<IUserRepository, UserStore>();
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddDbContext<ApplicationContext>(options => options.UseMySQL("server=localhost;user=root;database=JambRegistrationMVCUserRole;port=3306;password=ajibikeabdulqayyumambaaq"));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}