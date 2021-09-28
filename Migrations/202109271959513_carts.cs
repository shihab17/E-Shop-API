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
                    Id = c.Int(nullable: false, identity: true),
                    userId = c.Int(),
                    date = c.String(),
                    products_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}
