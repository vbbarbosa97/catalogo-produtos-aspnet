using System.Collections.Generic;
using System.Linq;
using catalago_api.Context;
using catalago_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catalago_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private AppDbContext database;
        public CategoriaController(AppDbContext context)
        {
            database = context;
        }

        [HttpGet("listar/produtos")]
        public ActionResult<IEnumerable<Categoria>> ListarCategoriaEProduto()
        {
            return database.Categorias.Include(x => x.Produtos).ToList();
        }

        [HttpGet("listar")]
        public ActionResult<IEnumerable<Categoria>> Listar()
        {
            return database.Categorias.ToList();
        }

        [HttpGet("{id}", Name = "obterCategoria")]
        public ActionResult<Categoria> Listar(int id)
        {
            var categoria = database.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        [HttpPost("criar")]
        public ActionResult Criar([FromBody] Categoria categoria)
        {
            database.Categorias.Add(categoria);
            database.SaveChanges();
            return new CreatedAtRouteResult("obterProduto", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            database.Entry(categoria).State = EntityState.Modified;
            database.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Deletar(int id)
        {
            var categoria = database.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            database.Categorias.Remove(categoria);
            database.SaveChanges();
            return categoria;
        }
    }
}