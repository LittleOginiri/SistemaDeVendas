using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaVendas.Model;

namespace SistemaVendas.DAO
{
    public class ItemVendaDAO
    {
        // Inserção simples de item de venda com apenas ID da venda e do produto
        // OBS: Essa versão parece estar obsoleta se todos os registros precisam de quantidade e valor
        // OBS: Eu nao vou mexer por que esta funcionando (° ʖ °)_b
        public void Inserir(int idVenda, int idProduto)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO ItensVendas
                  (id_venda, id_produto)
                VALUES
                  (@idVenda, @idProduto)";

            cmd.Parameters.AddWithValue("@idVenda", idVenda);
            cmd.Parameters.AddWithValue("@idProduto", idProduto);

            cmd.ExecuteNonQuery();
        }

        // Sobrecarga com inserção completa: quantidade e valor do item
        public void Inserir(int idVenda, int idProduto, int quantidade, decimal valorItem)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO ItensVendas
                  (id_venda, id_produto, quantidade, valor_item)
                VALUES
                  (@idVenda, @idProduto, @quantidade, @valorItem)";

            cmd.Parameters.AddWithValue("@idVenda", idVenda);
            cmd.Parameters.AddWithValue("@idProduto", idProduto);
            cmd.Parameters.AddWithValue("@quantidade", quantidade);
            cmd.Parameters.AddWithValue("@valorItem", valorItem);

            cmd.ExecuteNonQuery();
        }

        // Retorna todos os itens de venda registrados no banco
        public IEnumerable<ItemVenda> ObterTodos()
        {
            var lista = new List<ItemVenda>();

            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText = @"
                SELECT id_itemvenda, id_venda, id_produto, quantidade, valor_item
                  FROM ItensVendas";

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new ItemVenda
                {
                    IdItem = rdr.GetInt32(0),
                    IdVenda = rdr.GetInt32(1),
                    IdProduto = rdr.GetInt32(2),
                    Quantidade = rdr.GetInt32(3),
                    ValorItem = rdr.GetDecimal(4)
                });
            }

            return lista;
        }
    }
}
