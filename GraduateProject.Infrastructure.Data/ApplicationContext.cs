using GraduateProject.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GraduateProject.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Order> Orders { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                    new Book { Id = Guid.NewGuid(), Name = "Tom", Price = 37, Description = "Description of a book." },
                    new Book { Id = Guid.NewGuid(), Name = "Bob", Price = 41, Description = "Description of a book." },
                    new Book { Id = Guid.NewGuid(), Name = "Sam", Price = 24, Description = "Description of a book." }
            ); ; ;
            modelBuilder.Entity<User>().HasData(
                                   new User { Id = Guid.NewGuid(), Login = "qwe", Password = "qwe", },
                                   new User { Id = Guid.NewGuid(), Login = "asd", Password = "asd", },
                                   new User { Id = Guid.NewGuid(), Login = "dake", Password = "dake", });
        }
        
    }
}
