using HolidayManagement.Components;
using HolidayManagement.Database;
using HolidayManagement.Models;
using HolidayManagement.Services;
using HolidayManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MudBlazor.Services;
using System.Security.Claims;

namespace HolidayManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddMudServices();

            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddScoped<IModelService<UserData>, UserDataService>();
            builder.Services.AddScoped<IModelService<User>, UserService>();
            builder.Services.AddScoped<IModelService<Center>, CenterService>();
            builder.Services.AddScoped<IModelService<Institution>, InstitutionService>();
            builder.Services.AddScoped<IModelService<UserInstitution>, UserInstitutionService>();
            builder.Services.AddScoped<IModelService<Role>, RoleService>();
            builder.Services.AddScoped<IModelService<RoleGroup>, RoleGroupService>();


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "auth_token";
                options.LoginPath = "/public/login";
                options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                options.AccessDeniedPath = "/public/access-denied";
            });

            builder.Services.AddAuthorization();
            builder.Services.AddCascadingAuthenticationState();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapControllers();

            app.Run();
        }
    }
}
