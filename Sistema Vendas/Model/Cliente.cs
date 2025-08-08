namespace SistemaVendas.Model
{
    public class Cliente
    {
        // Identificador único do cliente (PK)
        public int IdCliente { get; set; }

        // Nome completo do cliente
        public string Nome { get; set; }

        // CPF do cliente (documento)
        public string CPF { get; set; }

        // Telefone de contato (opcional)
        public string Telefone { get; set; }

        // Email de contato (opcional)
        public string Email { get; set; }

        // FK para o usuário que cadastrou ou atualizou o cliente
        public int IdUsuario { get; set; }
    }
}
