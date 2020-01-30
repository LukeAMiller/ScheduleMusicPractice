using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ScheduleMusicPractice.Models;
namespace ScheduleMusicPractice.Data
{
    public class ApplicationDbContext : IdentityDbContext<Models.User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LearningMaterial> LearningMaterial { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Instrument> Instrument { get; set; }
        public DbSet<PracticeSession> PracticeSession { get; set; }
        public DbSet<PracticeMethod> PracticeMethod { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Building new users with Entity
            User user = new User
            {
                FullName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<User>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<LearningMaterial>().HasData(
             new LearningMaterial()
             {
                 id = 1,
                 Name = "http://www.flowkey.com",
                 InstrumentId = 1
             },
               new LearningMaterial()
               {
                   id = 2,
                   Name = "http://www.simplypiano.com",
                   InstrumentId = 1
               },
                 new LearningMaterial()
                 {
                     id = 3,
                     Name = "http://www.yousician.com",
                     InstrumentId = 2
                 });
            modelBuilder.Entity<Instrument>().HasData(
            new Instrument()
            {
                Id = 1,
                Name = "Piano"
            },
            new Instrument()
            {
                Id = 2,
                Name = "6-string Guitar"
            },
            new Instrument()
            {
                Id = 3,
                Name = "Otamatone"
            },
            new Instrument()
            {
                Id = 4,
                Name = "Kalimba"
            },
            new Instrument()
            {
                Id = 5,
                Name = "Harmonica"
            },
            new Instrument()
            {
                Id = 6,
                Name = "Bass Guitar"
            },
            new Instrument()
            {
                Id = 7,
                Name = "Vocals"
            }

        );
            modelBuilder.Entity<PracticeMethod>().HasData(
                new PracticeMethod()
                {
                    Id = 1,
                    Name = "Band"
                },
                new PracticeMethod()
                {
                    Id = 2,
                    Name = "Sheet Music"
                },
                new PracticeMethod()
                {
                    Id = 3,
                    Name = "Tutor"
                },
                new PracticeMethod()
                {
                    Id = 4,
                    Name = "Jamming"
                },
                new PracticeMethod()
                {
                    Id = 5,
                    Name = "Tabs"
                },
                new PracticeMethod()
                {
                    Id = 6,
                    Name = "App"
                }
                );
            modelBuilder.Entity<PracticeSession>().HasData(
                new PracticeSession()
                {
Id =1,
PracticeMethodId = 1,
InstrumentId =1,
dateTime = DateTime.Now,
UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                },
                  new PracticeSession()
                  {
                      Id = 2,
                      PracticeMethodId = 2,
                      InstrumentId = 2,
                      dateTime = DateTime.Now,
                      UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                  }, new PracticeSession()
                  {
                      Id = 3,
                      PracticeMethodId = 3,
                      InstrumentId = 3,
                      dateTime = DateTime.Now,
                      UserId = "00000000-ffff-ffff-ffff-ffffffffffff"

                  });
                }

    }
}
