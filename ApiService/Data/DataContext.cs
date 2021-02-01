using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Data {
    public class DataContext : DbContext {

        public DbSet<User> User { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Address> Address { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder
                .UseSqlServer(@"Server=162.246.16.98; Database=serp; User Id=erpdbuser; Password=fv84!Qc6;");
                //.UseSqlServer(@"Server=localhost; Database=AngularTesting; Trusted_Connection=True");
        }

    }
}
