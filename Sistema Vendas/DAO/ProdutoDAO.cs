using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaVendas.Model;

namespace SistemaVendas.DAO
{
    public class ProdutoDAO
    {
        // Retorna todos os produtos do banco
        public IEnumerable<Produto> ObterTodos()
        {
            var lista = new List<Produto>();

            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                "SELECT id_produto, nome, descricao, preco, estoque FROM Produtos";

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new Produto
                {
                    IdProduto = rdr.GetInt32(0),
                    Nome = rdr.GetString(1),
                    Descricao = rdr.GetString(2),
                    Preco = rdr.GetDecimal(3),
                    Estoque = rdr.GetInt32(4)
                });
            }

            return lista;
        }

        // Insere um novo produto na base de dados
        public void Inserir(Produto p)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                @"INSERT INTO Produtos (nome, descricao, preco, estoque)
                  VALUES (@nome, @desc, @preco, @estoque)";

            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@desc", p.Descricao);
            cmd.Parameters.AddWithValue("@preco", p.Preco);
            cmd.Parameters.AddWithValue("@estoque", p.Estoque);

            cmd.ExecuteNonQuery();
        }

        // Atualiza os dados de um produto já existente
        public void Atualizar(Produto p)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                @"UPDATE Produtos
                   SET nome      = @nome,
                       descricao = @desc,
                       preco     = @preco,
                       estoque   = @estoque
                 WHERE id_produto = @id";

            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@desc", p.Descricao);
            cmd.Parameters.AddWithValue("@preco", p.Preco);
            cmd.Parameters.AddWithValue("@estoque", p.Estoque);
            cmd.Parameters.AddWithValue("@id", p.IdProduto);

            cmd.ExecuteNonQuery();
        }

        // Remove um produto com base no ID
        public void Excluir(int id)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText = "DELETE FROM Produtos WHERE id_produto = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        // Reduz o estoque de um produto no banco com base na quantidade vendida.
        // Este método é invocado após uma venda confirmada.
     
        public void ReduzirEstoque(int idProduto, int quantidade)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                @"UPDATE Produtos
                   SET estoque = estoque - @q
                 WHERE id_produto = @id";

            cmd.Parameters.AddWithValue("@q", quantidade);
            cmd.Parameters.AddWithValue("@id", idProduto);

            cmd.ExecuteNonQuery();
        }
    }
}
