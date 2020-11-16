using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Data;
using TasksSystem.Repos;
using TasksSystem.Services;
using AutoMapper;
using TasksSystem.Models;

namespace TasksSystem
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
            services.AddDbContext<ClassLibraryContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ClassLibraryContext")));
            services.AddScoped<ProjectRepository>();
            services.AddScoped<ProjectService>();
            services.AddScoped<UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<ProjectUsersService>();
            services.AddScoped<ProjectUsersRepository>();
            services.AddScoped<TaskService>();
            services.AddScoped<TaskRepository>();
            services.AddScoped<CommentService>();
            services.AddScoped<CommentRepository>();
            services.AddControllersWithViews();

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
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
            //app.UseSession();
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
