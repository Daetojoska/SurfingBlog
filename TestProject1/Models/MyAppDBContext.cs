using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestProject1.Models
{
    public class MyAppDBContext:DbContext
    {
       public DbSet<Student> Students { get; set; }


        public MyAppDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                    new Student { Id = 1, Name = "Арина", Age = 20, Gender = 1 },
                    new Student { Id = 2, Name = "Даниил", Age = 21, Gender = 2 },
                    new Student { Id = 3, Name = "Светлана", Age = 22, Gender = 1 },
                    new Student { Id = 4, Name = "Александр", Age = 26, Gender = 2 },
                    new Student { Id = 5, Name = "Семен", Age = 24, Gender = 2 },
                    new Student { Id = 6, Name = "Яна", Age = 15, Gender = 1 });

        }
    }

}
