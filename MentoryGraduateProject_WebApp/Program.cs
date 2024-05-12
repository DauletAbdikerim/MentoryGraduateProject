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

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connection = "Server=(localdb)\\mssqllocaldb;Database=GraduateProject;Trusted_Connection=True;";
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/User/Login";
               });
            builder.Services.AddAuthorization();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapGet("/login", async (HttpContext context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                string loginForm = @"<!DOCTYPE html>
    <html>
    <head>
        <meta charset='utf-8' />
        <title>Login Form</title>
    </head>
    <body>
        <h2>Login Form</h2>
        <form method='post'>
            <p>
                <label>Login</label><br />
                <input name='login' />
            </p>
            <p>
                <label>Password</label><br />
                <input type='password' name='password' />
            </p>
            <input type='submit' value='Login' />
        </form>
    </body>
    </html>";
                await context.Response.WriteAsync(loginForm);
            });

            app.MapPost("/login", async (string? returnUrl, HttpContext context, IUserRepository userRepo) =>
            {
                var form = context.Request.Form;
                if (!form.ContainsKey("login") || !form.ContainsKey("password"))
                    return Results.BadRequest("Email and/or password are not provided");

                string login = form["login"];
                string password = form["password"];

                GraduateProject.Domain.Core.User? person = userRepo.GetUserByLoginAndPassword(login, password); 
                if (person is null)
                    return Results.Unauthorized();

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Login) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Results.Redirect(returnUrl ?? "/");
            });

            app.MapGet("/logout", async (HttpContext context) =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Results.Redirect("/login");
            });

            app.Map("/", [Authorize] () => $"Hello World!");

            app.Run();
        }
    }
}
