using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using StudentPortal.Data;
using StudentPortal.Repositry;

var builder = WebApplication.CreateBuilder(args);

// Register repository services
builder.Services.AddScoped<BookRepositry>();
builder.Services.AddScoped<LanguageRepositry>();

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

// Add Razor runtime compilation in development mode
#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif

// Register DbContexts for different databases
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("StudentPortal")));

builder.Services.AddDbContext<BookStoreContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("BookStore")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS for production
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Serve static files (e.g., images, CSS, JS)

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
// Configure default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
