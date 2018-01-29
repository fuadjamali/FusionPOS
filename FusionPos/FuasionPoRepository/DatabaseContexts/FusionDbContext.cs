using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using FusionPosModels;
using FusionPosModels.EntityModels;

namespace FuasionPoRepository.DatabaseContexts
{
    public class FusionDbContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseEntry> ExpenseEntries { get; set; }
        public DbSet<ExpenseEntryItems> ExpenseEntryItems { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<PurchaseReceive> PurchaseReceives { get; set; }
        public DbSet<PurchaseReceiveItems> PurchaseReceiveItems { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItems> SaleItemses { get; set; }

    }
}