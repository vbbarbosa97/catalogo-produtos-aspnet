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
    public class ProdutoController : ControllerBase
    {
        private AppDbContext database;
        public ProdutoController(AppDbContext context)
        {
            database = context;
        }

        [HttpGet("listar")]
        public ActionResult<IEnumerable<Produto>> Listar()
        {
            return database.Produtos.ToList();
        }

        [HttpGet("{id}", Name = "obterProduto")]
        public ActionResult<Produto> Listar(int id)
        {
            var produto = database.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPost("criar")]
        public ActionResult Criar([FromBody] Produto produto)
        {
            database.Produtos.Add(produto);
            database.SaveChanges();
            return new CreatedAtRouteResult("obterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            database.Entry(produto).State = EntityState.Modified;
            database.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Deletar(int id)
        {
            var produto = database.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            database.Produtos.Remove(produto);
            database.SaveChanges();
            return produto;
        }
    }
}