using GraduateProject.Domain.Core;
using GraduateProject.Domain.Interfaces;
using GraduateProject.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MentoryGraduateProject_WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            string connection = "Server=(localdb)\\mssqllocaldb;Database=GraduateProject;Trusted_Connection=True;";
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = "/Home/Error";
                    options.LoginPath = "/User/Login";
                });
            builder.Services.AddAuthorization();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();

            var app = builder.Build();

            // Seed data
            //SeedData(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }

        //public static void SeedData(IApplicationBuilder app)
        //{
        //    using (var serviceScope = app.ApplicationServices.CreateScope())
        //    {
        //        var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
        //        if (context != null)
        //        {
        //            if (!context.Users.Any())
        //            {
        //                context.Users.AddRange(
        //                    new User { Login = "admin", Password = "adminpass", Role = "Admin" },
        //                    new User { Login = "user", Password = "userpass", Role = "User" }
        //                );
        //            }

        //            if (!context.Books.Any())
        //            {
        //                context.Books.AddRange(
        //                    new Book { Name = "Book1", Description = "Description1", Price = 10 },
        //                    new Book { Name = "Book2", Description = "Description2", Price = 20 }
        //                );
        //            }

        //            context.SaveChanges();
        //        }
        //    }
        //}
    }
}
