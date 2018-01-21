using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FusionPosWeb.Models
{
    public class FusionDbContext : DbContext
    {
        public FusionDbContext():base("FusionDbContext")
        {
            
        }

        public DbSet<Organization> Organization { get; set; }
        public DbSet<Outlet> Outlet { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Party> Party { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public DbSet<ExpenseItem> ExpenseItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}