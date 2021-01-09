using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Data {
    public class DataContext : DbContext {

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder
                .UseSqlServer(@"Server=localhost; Database=AngularTesting; Trusted_Connection=True");
        }

    }
}
