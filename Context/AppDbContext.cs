using Microsoft.EntityFrameworkCore;
using catalago_api.Models;

namespace catalago_api.Context
{
    public class AppDbContext : DbContext
    {
        //Contexto que é registrado como um serviço
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Mapeando as entidades
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}