using Microsoft.EntityFrameworkCore;
using Core.Repositories;
using Core.Services;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Portfolio.Models;
using Portfolio.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using CloudinaryDotNet;
//using Portfolio.Data.ApplicationDbContext; // Alias to resolve conflict

/* 

add to the end of the add-migration and create-database commands:


-Context "Portfolio.Data.ApplicationDbContext"


*/
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);




var cloudinaryURL = builder.Configuration["Cloudinary:CLOUDINARY_URL"];
Cloudinary cloudinary = new Cloudinary(cloudinaryURL);
cloudinary.Api.Secure = true;

builder.Services.AddSingleton(cloudinary);

builder.Services.AddScoped<IImageUploadService, ImageUploadService>();


//var fakeSecretKey = builder.Configuration["fakeSecret:fakeSecretKey"];
//Console.WriteLine($"The fake secret key: {fakeSecretKey}");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped(typeof(IRoleRepository<>), typeof(RoleRepository<>));

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
//builder.Services.AddScoped(typeof(IRoleService1<>), typeof(RoleService<>));



builder.Services.AddIdentity<User, Role>(/*
    options => options.SignIn.RequireConfirmedAccount = true*/
    )
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
/*
//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<Role>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<Role>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();
*/
builder.Services.AddRazorPages();



builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();
//app.MapRazorPages();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
