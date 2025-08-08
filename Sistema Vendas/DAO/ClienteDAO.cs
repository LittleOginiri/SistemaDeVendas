// DAO/ClienteDAO.cs
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaVendas.Model;

namespace SistemaVendas.DAO
{
    public class ClienteDAO
    {
        // Retorna todos os clientes cadastrados no banco
        public IEnumerable<Cliente> ObterTodos()
        {
            var lista = new List<Cliente>();

            using var cn = Conexao.ObterConexao(); // Abre conexão
            using var cmd = new SqlCommand(@"
                SELECT id_cliente, nome, CPF, telefone, email
                  FROM Clientes
                 ORDER BY nome", cn); // Consulta todos os campos relevantes

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new Cliente
                {
                    IdCliente = rdr.GetInt32(0),
                    Nome = rdr.GetString(1),
                    CPF = rdr.GetString(2),
                    Telefone = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                    Email = rdr.IsDBNull(4) ? null : rdr.GetString(4)
                });
            }

            return lista;
        }

        // Retorna um cliente com base no ID
        public Cliente ObterPorId(int id)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = new SqlCommand(@"
                SELECT id_cliente, nome, CPF, telefone, email
                  FROM Clientes
                 WHERE id_cliente = @id", cn);

            cmd.Parameters.AddWithValue("@id", id);

            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read()) return null;

            return new Cliente
            {
                IdCliente = rdr.GetInt32(0),
                Nome = rdr.GetString(1),
                CPF = rdr.GetString(2),
                Telefone = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                Email = rdr.IsDBNull(4) ? null : rdr.GetString(4)
            };
        }

        // Insere novo cliente na tabela Clientes
        public void Inserir(Cliente cli)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = new SqlCommand(@"
                INSERT INTO Clientes (nome, CPF, telefone, email)
                     VALUES (@nome, @cpf, @tel, @email)", cn);

            cmd.Parameters.AddWithValue("@nome", cli.Nome);
            cmd.Parameters.AddWithValue("@cpf", cli.CPF);
            cmd.Parameters.AddWithValue("@tel", (object)cli.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object)cli.Email ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        // Atualiza os dados de um cliente existente
        public void Atualizar(Cliente cli)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = new SqlCommand(@"
                UPDATE Clientes
                   SET nome     = @nome,
                       CPF      = @cpf,
                       telefone = @tel,
                       email    = @email
                 WHERE id_cliente = @id", cn);

            cmd.Parameters.AddWithValue("@nome", cli.Nome);
            cmd.Parameters.AddWithValue("@cpf", cli.CPF);
            cmd.Parameters.AddWithValue("@tel", (object)cli.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object)cli.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", cli.IdCliente);

            cmd.ExecuteNonQuery();
        }

        // Remove cliente pelo ID
        // Ao gravar o uso houve um erro inesperado*
        public void Excluir(int id)
        {
            // 1º: Exclui usuários vinculados a este cliente
            using (var cn = Conexao.ObterConexao())
            using (var cmd = new SqlCommand("DELETE FROM Usuarios WHERE id_cliente = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            // 2º: Agora pode excluir o cliente
            using (var cn = Conexao.ObterConexao())
            using (var cmd = new SqlCommand("DELETE FROM Clientes WHERE id_cliente = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
