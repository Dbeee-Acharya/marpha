using marpha.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marpha.Data
{
    public class MarphaDbContext : DbContext
    {
        public MarphaDbContext(DbContextOptions<MarphaDbContext> option) :base(option)
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filname=marpha.db");
        }
    }
}
