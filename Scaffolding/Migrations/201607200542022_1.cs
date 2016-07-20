namespace Scaffolding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerCode = c.String(nullable: false, maxLength: 128),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
