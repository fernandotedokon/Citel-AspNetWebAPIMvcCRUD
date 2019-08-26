using Newtonsoft.Json;

namespace AspNetWebAPIMvcCRUD.Models.Entities
{
    public class ProdutoCategoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]
        public virtual Produto Produto { get; set; }
    }
}