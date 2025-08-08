using System;

namespace SistemaVendas.Model
{
    public class Venda
    {
        // Identificador da venda (PK)
        public int IdVenda { get; set; }

        // ID do cliente que realizou a compra (FK -> Cliente.IdCliente)
        public int IdCliente { get; set; }

        // ID do usuário que registrou a venda (FK -> Usuario.IdUsuario)
        public int IdUsuario { get; set; }

        // Data e hora em que a venda foi realizada
        public DateTime DataVenda { get; set; }

        // Valor total da venda (soma dos itens)
        public decimal Total { get; set; }
    }
}
