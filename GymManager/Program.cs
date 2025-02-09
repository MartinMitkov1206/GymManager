using GymManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register GymManagerContext with SQL Server (use your actual connection string)
builder.Services.AddDbContext<GymManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers and views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Exception handler for non-development environments
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTP Strict Transport Security (HSTS)
}
else
{
    app.UseDeveloperExceptionPage(); // Developer exception page for development environment
}

// HTTPS redirection
app.UseHttpsRedirection();

// Static files (e.g., CSS, JS, images)
app.UseStaticFiles();

// Routing
app.UseRouting();

// Authorization middleware
app.UseAuthorization();

// Configure default route for the app
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();
