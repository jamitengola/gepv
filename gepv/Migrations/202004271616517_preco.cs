namespace gepv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class preco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Saidas", "Preco", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Saidas", "Preco");
        }
    }
}
