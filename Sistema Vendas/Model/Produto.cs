namespace SistemaVendas.Model
{
    public class Produto
    {
        // Identificador único do produto (PK)
        public int IdProduto { get; set; }

        // Nome do produto
        public string Nome { get; set; }

        // Descrição opcional do produto
        public string Descricao { get; set; }

        // Preço unitário do produto
        public decimal Preco { get; set; }

        // Quantidade disponível em estoque
        public int Estoque { get; set; }
    }
}
