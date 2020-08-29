using catalago_api.Context;
using Microsoft.AspNetCore.Mvc;

namespace catalago_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController
    {
        private AppDbContext database;
        public CategoriaController(AppDbContext context)
        {
            database = context;
        }
        [HttpGet("listar")]
        public string Listar(){
            
            return "teste";
        }
    }
}