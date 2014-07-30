namespace MvcApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Linkchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LinkType = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        User = c.String(),
                        ToApplication_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ToApplication_Id)
                .Index(t => t.ToApplication_Id);
            
            AddColumn("dbo.Applications", "Manufacturer", c => c.String());
            AddColumn("dbo.Applications", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applications", "Modified", c => c.DateTime());
            AddColumn("dbo.Applications", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "ToApplication_Id", "dbo.Applications");
            DropIndex("dbo.Links", new[] { "ToApplication_Id" });
            DropColumn("dbo.Applications", "User");
            DropColumn("dbo.Applications", "Modified");
            DropColumn("dbo.Applications", "Created");
            DropColumn("dbo.Applications", "Manufacturer");
            DropTable("dbo.Links");
        }
    }
}
