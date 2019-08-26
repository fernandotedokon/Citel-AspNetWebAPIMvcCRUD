using System.Data.Entity.ModelConfiguration;
using AspNetWebAPIMvcCRUD.Models.Entities;

namespace AspNetWebAPIMvcCRUD.Models.Mapping
{
    public class ProdutoCategoriaMapping : EntityTypeConfiguration<ProdutoCategoria>
    {
        public ProdutoCategoriaMapping()
        {
            ToTable("ProdutoCategoria");

            HasKey(v => v.Id);

            Property(v => v.Nome).IsRequired().HasMaxLength(100);

            HasRequired<Produto>(r => r.Produto).WithMany(v => v.ProdutoCategorias)
                                          .WillCascadeOnDelete();
        }
    }
}