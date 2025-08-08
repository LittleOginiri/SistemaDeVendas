namespace SistemaVendas.Model
{
    public class Usuario
    {
        // Identificador único do usuário (PK)
        public int IdUsuario { get; set; }

        // Nome do usuário (associado a um cliente)
        public string Nome { get; set; }

        // Login de acesso ao sistema
        public string Login { get; set; }

        // Senha do usuário (armazenada como texto simples - atenção à segurança)
        public string Senha { get; set; }

        // Tipo do usuário: "Admin" ou "Comum"
        public string TipoUsuario { get; set; }

        // ID do cliente vinculado a este usuário (FK -> Clientes.IdCliente)
        public int IdCliente { get; set; }
    }
}
