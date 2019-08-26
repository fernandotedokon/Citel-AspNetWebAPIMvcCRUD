using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AspNetWebAPIMvcCRUD.Models.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataCadastro { get; private set; } = DateTime.Today;

        public bool Ativo { get; set; } = true;


        public int CategoriaId { get; set; }

        [JsonIgnore]
        public virtual Categoria Relproduto { get; set; }

        public virtual ICollection<ProdutoCategoria> ProdutoCategorias { get; set; }
    }
}