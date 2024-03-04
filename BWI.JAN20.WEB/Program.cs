using BWI.JAN20.WEB.Filters;
using BWI.JAN20.WEB.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BWIJAN20WEBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BWIJAN20WEBContext")));// ?? throw new InvalidOperationException("Connection string 'BWIJAN20WEBContext' not found.")));

// Add services to the container.
if (true)
    builder.Services.AddTransient<IBookService, BookService>();
else
    builder.Services.AddTransient<IBookService, BookService2>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie((config) =>
    {
        config.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        config.LoginPath = "/account/Login"; // Path for the redirect to user login page    
        //config.AccessDeniedPath = "/home/AccessDenied";

    });//()=>{}
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole("admin","user"));
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
       .RequireAuthenticatedUser()
       .Build();
});

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options =>
{
    options.Filters.Add<MyActionFilter>();
    options.Filters.Add<MyResultFilter>();
    options.Filters.Add<MyExceptionFilter>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
