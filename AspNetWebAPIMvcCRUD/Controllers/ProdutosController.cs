using FluentValidation;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using AspNetWebAPIMvcCRUD.Models.Context;
using AspNetWebAPIMvcCRUD.Models.Entities;
using AspNetWebAPIMvcCRUD.Models.Validation;
using System.Web.Http.OData.Query;
using AspNetWebAPIMvcCRUD.Filters;

namespace AspNetWebAPIMvcCRUD.Controllers
{
    public class ProdutosController : ApiController
    {
        private ProdutosContext db = new ProdutosContext();
        private ProdutoValidator validador = new ProdutoValidator();

        // GET: api/Produtos
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Select | AllowedQueryOptions.Skip | AllowedQueryOptions.Top,
                     MaxTop = 10,
                     PageSize = 10)]
        public IQueryable GetProdutos()
        {
            return db.Produtos.Where(v => v.Ativo);
        }

        // GET: api/Produtos/5
        public IHttpActionResult GetProduto(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            Produto produto = db.Produtos.Find(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }


        // POST: api/Produtos
        //[BasicAuhtentication]
        public IHttpActionResult PostProduto(Produto produto)
        {
            validador.ValidateAndThrow(produto);

            produto.Ativo = true;

            db.Produtos.Add(produto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
        }


        // PUT: api/Produtos/5
        //[BasicAuhtentication]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            if (id != produto.Id)
                return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

            if (db.Produtos.Count(v => v.Id == id) == 0)
                return NotFound();

            validador.ValidateAndThrow(produto);

            db.Entry(produto).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }




        // DELETE: api/Produtos/5
        //[BasicAuhtentication]
        public IHttpActionResult DeleteProduto(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            Produto produto = db.Produtos.Find(id);

            if (produto == null)
                return NotFound();

            db.Produtos.Remove(produto);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}