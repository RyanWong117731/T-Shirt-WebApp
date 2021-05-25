using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using T_Shirt_WebApp.Models;

namespace T_Shirt_WebApp.Data
{
    public class T_Shirt_WebAppContext : DbContext
    {
        public T_Shirt_WebAppContext (DbContextOptions<T_Shirt_WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<T_Shirt> T_Shirts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Shirt>().ToTable("T_Shirt");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<UserAccount>().ToTable("UserAccount");
        }
    }
}
