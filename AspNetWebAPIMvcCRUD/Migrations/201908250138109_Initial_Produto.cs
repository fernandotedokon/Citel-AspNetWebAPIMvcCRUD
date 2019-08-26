namespace AspNetWebAPIMvcCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Produto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.ProdutoCategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Produto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id, cascadeDelete: true)
                .Index(t => t.Produto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.ProdutoCategoria", "Produto_Id", "dbo.Produto");
            DropIndex("dbo.ProdutoCategoria", new[] { "Produto_Id" });
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            DropTable("dbo.ProdutoCategoria");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}
