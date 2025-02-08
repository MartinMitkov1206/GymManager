using GymManager.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Data
{
    public class GymManagerContext : DbContext
    {
        public GymManagerContext() 
            : base() {}

        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<Goal> Goal { get; set; }
        DbSet<Stats> Stats { get; set; }
        DbSet<Workout> Workout { get; set; }
        DbSet<WorkoutStats> WorkoutStats { get; set; }
        DbSet<WorkoutType> WorkoutType { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GymManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        
    }
}
