using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Context;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace AgriculturePresentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           

            builder.Services.AddDbContext<AgricultureContext>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AgricultureContext>();


            builder.Services.ContainerDependencies(); // Metodumuzu çaðýrdýk ( burdaki tanýmlamalarýmýz geçirdiðimiz sýnýftaki metot)


            // Bu kýsým sayfalarýma eriþim saðlanmasý için authentice olmuþ yani kimliði doðrulanmýþ bir kullanýcý gerekli.Onu inþa ediyoruz.

            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddMvc();

            builder.Services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index/";
                });





            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}