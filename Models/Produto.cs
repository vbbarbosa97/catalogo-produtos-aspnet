using System;

namespace catalago_api.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        //Referencia do relacionamento
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}