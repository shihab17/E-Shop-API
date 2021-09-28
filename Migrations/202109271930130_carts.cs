namespace OnlineShopWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        date = c.String(),
                        products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.products_Id)
                .Index(t => t.products_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "products_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "products_Id" });
            DropTable("dbo.Carts");
        }
    }
}
