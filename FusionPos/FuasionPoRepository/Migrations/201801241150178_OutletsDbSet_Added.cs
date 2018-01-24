namespace FuasionPoRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OutletsDbSet_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Outlets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        ContactNo = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outlets", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Outlets", new[] { "OrganizationId" });
            DropTable("dbo.Outlets");
        }
    }
}
