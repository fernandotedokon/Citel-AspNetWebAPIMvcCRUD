using System.Data.Entity.ModelConfiguration;
using AspNetWebAPIMvcCRUD.Models.Entities;

namespace AspNetWebAPIMvcCRUD.Models.Mapping
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            ToTable("Categoria");

            HasKey(v => v.Id);

            Property(v => v.Nome).IsRequired().HasMaxLength(100);
        }
    }
}