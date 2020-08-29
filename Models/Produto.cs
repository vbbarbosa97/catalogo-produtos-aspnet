using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalago_api.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string ImagemUrl { get; set; }
        
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        //Referencia do relacionamento
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}