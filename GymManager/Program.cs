using System;
using GymManager.Data;
using GymManager.Helpers;
using GymManager.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<GymManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication("GymManagerAuth")
    .AddCookie("GymManagerAuth", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

var app = builder.Build();

// ──────────────── SEED DATABASE ON STARTUP ───────────────────────────
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<GymManagerContext>();
    // apply any pending migrations
    ctx.Database.Migrate();

    // 1) Seed Roles if missing
    if (!ctx.Role.Any(r => r.RoleType == "User"))
        ctx.Role.Add(new Role { RoleType = "User" });
    if (!ctx.Role.Any(r => r.RoleType == "Trainer"))
        ctx.Role.Add(new Role { RoleType = "Trainer" });
    ctx.SaveChanges();

    // 2) Seed the 8 trainer accounts if none exist yet
    var trainerRoleId = ctx.Role.Single(r => r.RoleType == "Trainer").RoleID;
    if (!ctx.User.Any(u => u.RoleID == trainerRoleId))
    {
        var salt = PasswordHelper.GenerateSalt();
        var hash = PasswordHelper.HashPassword("1245", salt);

        var trainers = new[]
        {
            new User { UserName = "QsenTrainer", Email = "qsentrainer@gmail.com", PasswordSalt = salt, PasswordHash = hash, Age = 30, RoleID = trainerRoleId, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new User { UserName = "KamenTrainer", Email = "kamentrainer@gmail.com", PasswordSalt = salt, PasswordHash = hash, Age = 30, RoleID = trainerRoleId, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new User { UserName = "MartinTrainer", Email = "martintrainer@gmail.com", PasswordSalt = salt, PasswordHash = hash, Age = 30, RoleID = trainerRoleId, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new User { UserName = "ErenTrainer", Email = "erentrainer@gmail.com", PasswordSalt = salt, PasswordHash = hash, Age = 30, RoleID = trainerRoleId, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new User { UserName = "PavelTrainer", Email = "paveltrainer@gmail.com", PasswordSalt = salt, PasswordHash = hash, Age = 30, RoleID = trainerRoleId, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new User { UserName = "MishoTrainer", Email = "mishotrainer@gmail.com", PasswordSalt = salt, PasswordHash = hash, Age = 30, RoleID = trainerRoleId, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new User { UserName = "MiroTrainer", Email = "mirotrainer@gmail.com", PasswordSalt = salt, PasswordHash = hash, Age = 30, RoleID = trainerRoleId, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new User { UserName = "JulyTrainer", Email = "julytrainer@gmail.com", PasswordSalt = salt, PasswordHash = hash, Age = 30, RoleID = trainerRoleId, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
        };

        ctx.User.AddRange(trainers);
        ctx.SaveChanges();
    }
}
// ────────────────────────────────────────────────────────────────────────

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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
