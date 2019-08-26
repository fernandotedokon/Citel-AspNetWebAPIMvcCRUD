using System.Data.Entity;
using AspNetWebAPIMvcCRUD.Models.Entities;
using AspNetWebAPIMvcCRUD.Models.Mapping;

namespace AspNetWebAPIMvcCRUD.Models.Context
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext() : base("DbLoja")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Produto>(new ProdutoMapping());
            modelBuilder.Configurations.Add<Categoria>(new CategoriaMapping());
            modelBuilder.Configurations.Add<ProdutoCategoria>(new ProdutoCategoriaMapping());
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
    }
}