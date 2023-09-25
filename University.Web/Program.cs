using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using University.Web.Data;
using University.Web.Models;
using University.Web.Repository;
using University.Web.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository> ();
builder.Services.AddDbContext<UniversityDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityConnectionString")
));

builder.Services.AddDbContext<AuthDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityAuthDbConnectionString"))
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AuthDbContext>()
        .AddDefaultTokenProviders();
builder.Services.AddScoped(typeof(IBaseRepository<Course>), typeof(BaseRepository<Course>));



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
