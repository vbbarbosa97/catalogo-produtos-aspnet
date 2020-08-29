using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace catalago_api.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        // Os campos no banco de dados
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }

        // Referencia de relacionamento com a tabela produtos
        // Uma categoria possui N produtos vinculados
        public ICollection<Produto> Produtos { get; set; }
    }
}