using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaVendas.Model;

namespace SistemaVendas.DAO
{
    public class VendaDAO
    {
        
        // Insere uma nova venda na tabela e retorna o ID gerado (identity).
        // A tabela Vendas contém: id_usuario, data_venda, valor.
         
        public int Inserir(Venda venda)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = new SqlCommand(@"
                INSERT INTO Vendas (id_usuario, data_venda, valor)
                VALUES (@idUsuario, @dataVenda, @valor);
                SELECT CAST(SCOPE_IDENTITY() AS INT);", cn); // Retorna o último ID inserido

            cmd.Parameters.AddWithValue("@idUsuario", venda.IdUsuario);
            cmd.Parameters.AddWithValue("@dataVenda", venda.DataVenda);
            cmd.Parameters.AddWithValue("@valor", venda.Total);

            return (int)cmd.ExecuteScalar(); // Retorna ID da venda
        }

         
        // Retorna todas as vendas cadastradas no banco.
         
        public IEnumerable<Venda> ObterTodos()
        {
            var lista = new List<Venda>();

            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();
            cmd.CommandText = @"
                SELECT id_venda
                     , id_usuario
                     , data_venda
                     , valor AS total
                  FROM Vendas";

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new Venda
                {
                    IdVenda = rdr.GetInt32(0),
                    IdUsuario = rdr.GetInt32(1),
                    DataVenda = rdr.GetDateTime(2),
                    Total = rdr.GetDecimal(3)
                });
            }

            return lista;
        }

         
        // Retorna apenas as vendas realizadas por um determinado usuário.
         
        public IEnumerable<Venda> ObterPorUsuario(int usuarioId)
        {
            var lista = new List<Venda>();

            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText = @"
                SELECT id_venda
                     , id_usuario
                     , data_venda
                     , valor AS total
                  FROM Vendas
                 WHERE id_usuario = @usuarioId";

            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new Venda
                {
                    IdVenda = rdr.GetInt32(0),
                    IdUsuario = rdr.GetInt32(1),
                    DataVenda = rdr.GetDateTime(2),
                    Total = rdr.GetDecimal(3)
                });
            }

            return lista;
        }

         
        // Atualiza os dados de uma venda (data e valor).
         
        public void Atualizar(Venda venda)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText = @"
                UPDATE Vendas
                   SET data_venda = @dataVenda,
                       valor      = @valor
                 WHERE id_venda   = @idVenda";

            cmd.Parameters.AddWithValue("@dataVenda", venda.DataVenda);
            cmd.Parameters.AddWithValue("@valor", venda.Total);
            cmd.Parameters.AddWithValue("@idVenda", venda.IdVenda);

            cmd.ExecuteNonQuery();
        }

         
        // Remove uma venda do banco com base no ID.
         
        public void Excluir(int idVenda)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText = "DELETE FROM Vendas WHERE id_venda = @idVenda";
            cmd.Parameters.AddWithValue("@idVenda", idVenda);

            cmd.ExecuteNonQuery();
        }
    }
}
