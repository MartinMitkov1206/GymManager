using GymManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using GymManager.Models; // Import IHttpContextAccessor


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GymManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// **Register IHttpContextAccessor**
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

// **Add Session Services**
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout (30 minutes)
    options.Cookie.HttpOnly = true; // Prevents JavaScript access
    options.Cookie.IsEssential = true; // Ensures session works even if tracking is disabled
});

// **Add Authentication Middleware (Needed for Login)**
builder.Services.AddAuthentication("GymManagerAuth")
    .AddCookie("GymManagerAuth", options =>
    {
        options.LoginPath = "/Account/Login";  // Redirect to Login if unauthorized
        options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect if no access
    });


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GymManagerContext>();

    if (!context.Role.Any(r => r.RoleType == "User"))
    {
        context.Role.Add(new Role { RoleType = "User" });
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// **Enable Sessions**
app.UseSession();

// **Enable Authentication and Authorization**
app.UseAuthentication();
app.UseAuthorization();

// Configure default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
