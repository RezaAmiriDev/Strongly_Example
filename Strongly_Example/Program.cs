
using ClassLibrary;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using Strongly_Example.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
IServiceCollection serviceCollection = builder.Services.AddDbContext<MyCmsContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("Defult")));
builder.Services.AddScoped<IGroupPageRepository, GroupPageService>();
builder.Services.AddScoped<IPageRepository, PageService>();

// Configure cookie-based authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Redirect to login page
        options.LogoutPath = "/Account/Logout"; // Redirect to logout page
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration time
    });


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


#pragma warning disable ASP0014
app.UseEndpoints(endpoint =>
{
    endpoint.MapAreaControllerRoute(
        name: "Admin",
        areaName : "admin",
        pattern: "admin/{controller=GroupPage}/{action=Index}/{id?}");

    endpoint.MapAreaControllerRoute(
     name: "admin",
     areaName: "admin",
     pattern: "admin/{controller=Page}/{action=Index}/{id?}");

    endpoint.MapAreaControllerRoute(
       name: "admin",
       areaName: "admin",
       pattern: "admin/{controller=Page}/{action=Create}/{id?}");

    endpoint.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

});



app.Run();
