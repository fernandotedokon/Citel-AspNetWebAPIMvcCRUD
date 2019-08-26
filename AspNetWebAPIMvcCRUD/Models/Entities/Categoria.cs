using Newtonsoft.Json;
using System.Collections.Generic;

namespace AspNetWebAPIMvcCRUD.Models.Entities
{

    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}