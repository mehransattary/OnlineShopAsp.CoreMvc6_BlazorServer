using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Interface;
using Repository.Services;
using Repository.Servicesl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option=> option.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IAdvertiseService, AdvertiseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBlogCategoryService, BlogCategoryService>();
builder.Services.AddScoped<IBlogGroupService, BlogGroupService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IZarinPalService, ZarinPalService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(op => 
    {
        op.LoginPath = "/Account/Login";
        op.LogoutPath = "/Account/LogOut";
        op.ExpireTimeSpan = TimeSpan.FromDays(10);
      
    });

builder.Services.AddCors(op => op.AddPolicy("AllowPolicy",
    p => p.WithOrigins("htpps://localhost:7022").AllowAnyMethod().AllowAnyHeader().AllowCredentials()
    )); 

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
app.UseCors("AllowPolicy");

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(option => 
{

    option.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
         );

    option.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});


app.MapBlazorHub();
app.Run();
