namespace SistemaVendas.Model
{
    public class ItemVenda
    {
        // Identificador do item vendido (PK)
        public int IdItem { get; set; }

        // ID da venda a que este item pertence (FK para Vendas)
        public int IdVenda { get; set; }

        // ID do produto vendido (FK para Produtos)
        public int IdProduto { get; set; }

        // Quantidade de unidades do produto na venda
        public int Quantidade { get; set; }

        // Valor total do item (preço unitário × quantidade)
        public decimal ValorItem { get; set; }
    }
}
