using BookStore;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<ContactUs> Message { get; set; }
    }
}
