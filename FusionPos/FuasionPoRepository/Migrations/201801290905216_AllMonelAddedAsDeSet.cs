namespace FuasionPoRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllMonelAddedAsDeSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        OutletId = c.Int(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        Image = c.Binary(),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ReferenceId = c.Int(nullable: false),
                        EmergencyContactNo = c.String(nullable: false),
                        Nid = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        MotherName = c.String(),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Outlets", t => t.OutletId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ReferenceId)
                .Index(t => t.OutletId)
                .Index(t => t.ReferenceId);
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        IsRoot = c.Boolean(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ExpenseEntries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OutletId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                        Outlet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Outlets", t => t.Outlet_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Outlet_Id);
            
            CreateTable(
                "dbo.ExpenseEntryItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ExpenseItemId = c.Long(nullable: false),
                        Description = c.String(),
                        Qty = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        ExpenseEntryId = c.Long(nullable: false),
                        ExpenseItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseEntries", t => t.ExpenseEntryId, cascadeDelete: true)
                .ForeignKey("dbo.ExpenseItems", t => t.ExpenseItem_Id)
                .Index(t => t.ExpenseEntryId)
                .Index(t => t.ExpenseItem_Id);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ExpenseCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryId, cascadeDelete: true)
                .Index(t => t.ExpenseCategoryId);
            
            CreateTable(
                "dbo.PurchaseReceiveItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ItemId = c.Long(nullable: false),
                        Qty = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Item_Id = c.Int(),
                        PurchaseReceive_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.PurchaseReceives", t => t.PurchaseReceive_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.PurchaseReceive_Id);
            
            CreateTable(
                "dbo.PurchaseReceives",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        No = c.String(nullable: false, maxLength: 11),
                        Date = c.DateTime(nullable: false),
                        SupplierId = c.Long(nullable: false),
                        OutletId = c.Long(nullable: false),
                        PurchaseById = c.Long(nullable: false),
                        Remarks = c.String(),
                        Outlet_Id = c.Int(nullable: false),
                        PurchaseBy_Id = c.Int(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Outlets", t => t.Outlet_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.PurchaseBy_Id)
                .ForeignKey("dbo.Parties", t => t.Supplier_Id)
                .Index(t => t.Outlet_Id)
                .Index(t => t.PurchaseBy_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Contact = c.String(maxLength: 50),
                        Email = c.String(),
                        Image = c.Binary(),
                        Address = c.String(),
                        IsCustomer = c.Boolean(nullable: false),
                        IsSupplier = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ItemId = c.Long(nullable: false),
                        Qty = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Item_Id = c.Int(),
                        Sale_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Sale_Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        No = c.String(nullable: false, maxLength: 11),
                        Date = c.DateTime(nullable: false),
                        OutletId = c.Long(nullable: false),
                        SoldById = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        Vat = c.Double(),
                        Discount = c.Double(),
                        Customer_Id = c.Int(),
                        Outlet_Id = c.Int(),
                        SoldBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Customer_Id)
                .ForeignKey("dbo.Outlets", t => t.Outlet_Id)
                .ForeignKey("dbo.Employees", t => t.SoldBy_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Outlet_Id)
                .Index(t => t.SoldBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "SoldBy_Id", "dbo.Employees");
            DropForeignKey("dbo.Sales", "Outlet_Id", "dbo.Outlets");
            DropForeignKey("dbo.SaleItems", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Sales", "Customer_Id", "dbo.Parties");
            DropForeignKey("dbo.SaleItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.PurchaseReceives", "Supplier_Id", "dbo.Parties");
            DropForeignKey("dbo.PurchaseReceives", "PurchaseBy_Id", "dbo.Employees");
            DropForeignKey("dbo.PurchaseReceives", "Outlet_Id", "dbo.Outlets");
            DropForeignKey("dbo.PurchaseReceiveItems", "PurchaseReceive_Id", "dbo.PurchaseReceives");
            DropForeignKey("dbo.PurchaseReceiveItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ExpenseEntries", "Outlet_Id", "dbo.Outlets");
            DropForeignKey("dbo.ExpenseEntryItems", "ExpenseItem_Id", "dbo.ExpenseItems");
            DropForeignKey("dbo.ExpenseItems", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.ExpenseEntryItems", "ExpenseEntryId", "dbo.ExpenseEntries");
            DropForeignKey("dbo.ExpenseEntries", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ExpenseCategories", "ParentId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.Employees", "ReferenceId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "OutletId", "dbo.Outlets");
            DropIndex("dbo.Sales", new[] { "SoldBy_Id" });
            DropIndex("dbo.Sales", new[] { "Outlet_Id" });
            DropIndex("dbo.Sales", new[] { "Customer_Id" });
            DropIndex("dbo.SaleItems", new[] { "Sale_Id" });
            DropIndex("dbo.SaleItems", new[] { "Item_Id" });
            DropIndex("dbo.PurchaseReceives", new[] { "Supplier_Id" });
            DropIndex("dbo.PurchaseReceives", new[] { "PurchaseBy_Id" });
            DropIndex("dbo.PurchaseReceives", new[] { "Outlet_Id" });
            DropIndex("dbo.PurchaseReceiveItems", new[] { "PurchaseReceive_Id" });
            DropIndex("dbo.PurchaseReceiveItems", new[] { "Item_Id" });
            DropIndex("dbo.ExpenseItems", new[] { "ExpenseCategoryId" });
            DropIndex("dbo.ExpenseEntryItems", new[] { "ExpenseItem_Id" });
            DropIndex("dbo.ExpenseEntryItems", new[] { "ExpenseEntryId" });
            DropIndex("dbo.ExpenseEntries", new[] { "Outlet_Id" });
            DropIndex("dbo.ExpenseEntries", new[] { "Employee_Id" });
            DropIndex("dbo.ExpenseCategories", new[] { "ParentId" });
            DropIndex("dbo.Employees", new[] { "ReferenceId" });
            DropIndex("dbo.Employees", new[] { "OutletId" });
            DropTable("dbo.Sales");
            DropTable("dbo.SaleItems");
            DropTable("dbo.Parties");
            DropTable("dbo.PurchaseReceives");
            DropTable("dbo.PurchaseReceiveItems");
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseEntryItems");
            DropTable("dbo.ExpenseEntries");
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.Employees");
        }
    }
}
