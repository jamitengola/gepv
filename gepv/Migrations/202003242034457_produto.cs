namespace gepv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class produto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereço = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Entradas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Datachegada = c.DateTime(nullable: false),
                        Fornecedor_Id = c.Int(),
                        Produto_Id = c.Int(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedors", t => t.Fornecedor_Id)
                .ForeignKey("dbo.Produtos", t => t.Produto_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Fornecedor_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                        Telefone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Quantidade = c.Int(nullable: false),
                        Imagem = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Preco = c.Double(nullable: false),
                        Categoria_Id = c.Int(),
                        Fornecedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .ForeignKey("dbo.Fornecedors", t => t.Fornecedor_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Fornecedor_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Saidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        DataSaida = c.DateTime(nullable: false),
                        Cliente_Id = c.Int(),
                        Produto_Id = c.Int(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Produtos", t => t.Produto_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saidas", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Saidas", "Produto_Id", "dbo.Produtos");
            DropForeignKey("dbo.Saidas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Entradas", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Entradas", "Produto_Id", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "Fornecedor_Id", "dbo.Fornecedors");
            DropForeignKey("dbo.Produtos", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Entradas", "Fornecedor_Id", "dbo.Fornecedors");
            DropIndex("dbo.Saidas", new[] { "Usuario_Id" });
            DropIndex("dbo.Saidas", new[] { "Produto_Id" });
            DropIndex("dbo.Saidas", new[] { "Cliente_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Produtos", new[] { "Fornecedor_Id" });
            DropIndex("dbo.Produtos", new[] { "Categoria_Id" });
            DropIndex("dbo.Entradas", new[] { "Usuario_Id" });
            DropIndex("dbo.Entradas", new[] { "Produto_Id" });
            DropIndex("dbo.Entradas", new[] { "Fornecedor_Id" });
            DropTable("dbo.Saidas");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Produtos");
            DropTable("dbo.Fornecedors");
            DropTable("dbo.Entradas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
