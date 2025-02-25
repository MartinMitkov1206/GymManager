using GymManager.Models;
using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<TrainerClient> TrainerClients { get; set; } // New table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure TrainerClient relationships to disable cascading deletes
            modelBuilder.Entity<TrainerClient>()
                .HasOne(tc => tc.Trainer)
                .WithMany()
                .HasForeignKey(tc => tc.TrainerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrainerClient>()
                .HasOne(tc => tc.Client)
                .WithMany()
                .HasForeignKey(tc => tc.ClientID)
                .OnDelete(DeleteBehavior.NoAction);

            //Seed Roles (if not already seeded)
            /*modelBuilder.Entity<Role>().HasData(
                modelBuilder.Entity<Role>().HasData(

                new Role { RoleID = 1, RoleType = "User" },
                new Role { RoleID = 2, RoleType = "Trainer" }
            ));*/
            // Temporarily seed eight trainer accounts as default users (RoleID = 1)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 101,
                    UserName = "QsenTrainer",
                    Email = "qsentrainer@gmail.com",
                    PasswordHash = "1245",
                    PasswordSalt = "1245",
                    Age = 30,
                    //RoleID = 1, // Temporarily not set as Trainer
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    UserID = 102,
                    UserName = "KamenTrainer",
                    Email = "kamentrainer@gmail.com",
                    PasswordHash = "1245",
                    PasswordSalt = "1245",
                    Age = 30,
                    RoleID = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    UserID = 103,
                    UserName = "MartinTrainer",
                    Email = "martintrainer@gmail.com",
                    PasswordHash = "1245",
                    PasswordSalt = "1245",
                    Age = 30,
                    RoleID = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    UserID = 104,
                    UserName = "ErenTrainer",
                    Email = "erentrainer@gmail.com",
                    PasswordHash = "1245",
                    PasswordSalt = "1245",
                    Age = 30,
                    RoleID = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    UserID = 105,
                    UserName = "PavelTrainer",
                    Email = "paveltrainer@gmail.com",
                    PasswordHash = "1245",
                    PasswordSalt = "1245",
                    Age = 30,
                    RoleID = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    UserID = 106,
                    UserName = "MishoTrainer",
                    Email = "mishotrainer@gmail.com",
                    PasswordHash = "1245",
                    PasswordSalt = "1245",
                    Age = 30,
                    RoleID = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    UserID = 107,
                    UserName = "MiroTrainer",
                    Email = "mirotrainer@gmail.com",
                    PasswordHash = "1245",
                    PasswordSalt = "1245",
                    Age = 30,
                    RoleID = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    UserID = 108,
                    UserName = "JulyTrainer",
                    Email = "julytrainer@gmail.com",
                    PasswordHash = "1245",
                    PasswordSalt = "1245",
                    Age = 30,
                    RoleID = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GymManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
