namespace FuasionPoRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee_setup_added : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ReferenceId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "OutletId", "dbo.Outlets");
            DropIndex("dbo.Employees", new[] { "ReferenceId" });
            DropIndex("dbo.Employees", new[] { "OutletId" });
            DropTable("dbo.Employees");
        }
    }
}
