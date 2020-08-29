using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalago_api.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        // Os campos no banco de dados

        [Key]
        public int CategoriaId { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        
        [Required]
        [MaxLength(300)]
        public string ImagemUrl { get; set; }

        // Referencia de relacionamento com a tabela produtos
        // Uma categoria possui N produtos vinculados
        public ICollection<Produto> Produtos { get; set; }
    }
}