namespace gepv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "Imagem", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Imagem", c => c.Int(nullable: false));
        }
    }
}
