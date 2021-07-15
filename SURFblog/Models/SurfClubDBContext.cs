using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurfClub.Models.DbModels;

namespace SurfClub.Models
{
    public class SurfClubDBContext:DbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }


        public SurfClubDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Nickname = "Test",
                    Email = "test@mail.ru",
                    Password = "123456",
                    Photo = new Guid("498d7e21-cb9b-43a6-9e5b-37fcb41e273f")
                });

        }

    }
}
