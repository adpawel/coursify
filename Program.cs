//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Coursify.Data;
//using Coursify.Areas.Identity.Data;
//using Coursify.Middleware;
//using Microsoft.Extensions.DependencyInjection;

//var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("CoursifyContextConnection") ?? throw new InvalidOperationException("Connection string 'CoursifyContextConnection' not found.");;

//builder.Services.AddDbContext<CoursifyContext>(options => options.UseSqlite(connectionString));

//builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<CoursifyContext>()
//    .AddDefaultTokenProviders();

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();
//builder.Services.AddControllers();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//        policy.AllowAnyOrigin()
//              .AllowAnyHeader()
//              .AllowAnyMethod());
//});

//var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

//    // Asynchronicznie wywo�ujemy metody synchronizuj�c je tutaj:
//    Task.Run(async () =>
//    {
//        if (!await roleManager.RoleExistsAsync("Admin"))
//        {
//            await roleManager.CreateAsync(new IdentityRole("Admin"));
//        }

//        var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
//        if (adminUser != null && !(await userManager.IsInRoleAsync(adminUser, "Admin")))
//        {
//            await userManager.AddToRoleAsync(adminUser, "Admin");
//        }
//    }).GetAwaiter().GetResult();
//}


//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseCors("AllowAll");
//app.UseRouting();
//app.UseMiddleware<ApiKeyAuthMiddleware>();
//app.UseAuthentication();
//app.UseAuthorization();
//app.MapControllers();
//app.MapStaticAssets();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}")
//    .WithStaticAssets();
//app.MapRazorPages();

//app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Coursify.Data;
using Coursify.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CoursifyContextConnection") ?? throw new InvalidOperationException("Connection string 'CoursifyContextConnection' not found."); ;

builder.Services.AddDbContext<CoursifyContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CoursifyContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

app.Run();