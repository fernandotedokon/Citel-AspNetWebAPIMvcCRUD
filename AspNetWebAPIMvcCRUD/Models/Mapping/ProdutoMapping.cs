using System.Data.Entity.ModelConfiguration;
using AspNetWebAPIMvcCRUD.Models.Entities;

namespace AspNetWebAPIMvcCRUD.Models.Mapping
{
    public class ProdutoMapping : EntityTypeConfiguration<Produto>
    {
        public ProdutoMapping()
        {
            ToTable("Produto");

            HasKey(v => v.Id);

            Property(v => v.Nome).IsRequired().HasMaxLength(100);
            Property(v => v.Preco).IsRequired();
            Property(v => v.DataCadastro).IsRequired();

            HasRequired<Categoria>(v => v.Relproduto).WithMany(e => e.Produtos)
                                                   .HasForeignKey(v => v.CategoriaId)
                                                   .WillCascadeOnDelete();
        }
    }
}