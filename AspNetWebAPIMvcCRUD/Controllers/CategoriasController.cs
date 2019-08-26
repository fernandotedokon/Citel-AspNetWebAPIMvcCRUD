using FluentValidation;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using AspNetWebAPIMvcCRUD.Filters;
using AspNetWebAPIMvcCRUD.Models.Context;
using AspNetWebAPIMvcCRUD.Models.Entities;
using AspNetWebAPIMvcCRUD.Models.Validation;

namespace AspNetWebAPIMvcCRUD.Controllers
{
    public class CategoriasController : ApiController
    {
        private ProdutosContext db = new ProdutosContext();
        private CategoriaValidator validador = new CategoriaValidator();

        // GET: api/Categorias
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.Skip | AllowedQueryOptions.Top | AllowedQueryOptions.InlineCount,
                     MaxTop = 10,
                     PageSize = 10)]
        public IQueryable<Categoria> GetCategorias()
        {
            return db.Categorias;
        }

        // GET: api/Categorias/5
        public IHttpActionResult GetCategoria(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            Categoria categoria = db.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [Route("api/categorias/{id}/produtos")]
        public IHttpActionResult GetProdutos(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            Categoria categoria = db.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria.Produtos);
        }
        // PUT: api/Categorias/5
        //[BasicAuhtentication]
        public IHttpActionResult PutCategoria(int id, Categoria categoria)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            if (id != categoria.Id)
                return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

            if (db.Categorias.Count(e => e.Id == id) == 0)
                return NotFound();

            validador.ValidateAndThrow(categoria);

            db.Entry(categoria).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categorias
        //[BasicAuhtentication]
        public IHttpActionResult PostCategoria(Categoria categoria)
        {
            validador.ValidateAndThrow(categoria);

            db.Categorias.Add(categoria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        //[BasicAuhtentication]
        public IHttpActionResult DeleteCategoria(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            Categoria categoria = db.Categorias.Find(id);

            if (categoria == null)
                return NotFound();

            if(categoria.Produtos.Count(v => v.Ativo) > 0)
                return Content(HttpStatusCode.Forbidden, "Essa categoria não pode ser excluída, pois há produtos ativos relacionadas a ela.");

            db.Categorias.Remove(categoria);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}