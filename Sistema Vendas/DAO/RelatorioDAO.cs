using System.Collections.Generic;
using System.Data.SqlClient; // Necessário para conexão com SQL Server
using SistemaVendas.Model;

namespace SistemaVendas.DAO
{
    public class RelatorioDAO
    {
        // Retorna o total de unidades vendidas de um determinado produto
        public int ObterTotalVendidoPorProduto(int idProduto)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = new SqlCommand(@"
                SELECT ISNULL(SUM(quantidade), 0)
                  FROM ItensVendas
                 WHERE id_produto = @id", cn);

            cmd.Parameters.AddWithValue("@id", idProduto);

            // Usa ExecuteScalar para retornar o valor único da consulta
            return (int)cmd.ExecuteScalar();
        }

        // Obtém a lista de produtos a partir do ProdutoDAO
        public IEnumerable<Produto> ObterProdutos()
            => new ProdutoDAO().ObterTodos(); // Reaproveita lógica existente

        // Retorna a receita por mês para um período específico de um ano
        public IEnumerable<ReceitaMes> ObterReceitaMensal(int ano, int mesInicio, int mesFim)
        {
            var lista = new List<ReceitaMes>();

            using var cn = Conexao.ObterConexao();
            using var cmd = new SqlCommand(@"
                SELECT MONTH(data_venda) AS Mes,
                       SUM(valor)       AS Total
                  FROM Vendas
                 WHERE YEAR(data_venda) = @ano
                   AND MONTH(data_venda) BETWEEN @ini AND @fim
                 GROUP BY MONTH(data_venda)
                 ORDER BY MONTH(data_venda);", cn);

            cmd.Parameters.AddWithValue("@ano", ano);
            cmd.Parameters.AddWithValue("@ini", mesInicio);
            cmd.Parameters.AddWithValue("@fim", mesFim);

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new ReceitaMes
                {
                    Mes = rdr.GetInt32(0),
                    Total = rdr.GetDecimal(1)
                });
            }

            return lista;
        }
    }
}
