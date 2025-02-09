using GymManager.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Data
{
    public class GymManagerContext : DbContext
    {
        public GymManagerContext(DbContextOptions<GymManagerContext> options)
           : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<WorkoutStats> WorkoutStats { get; set; }
        public DbSet<WorkoutType> WorkoutType { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GymManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        
    }
}
