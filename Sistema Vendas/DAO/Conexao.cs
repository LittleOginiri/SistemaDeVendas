using System.Data.SqlClient;

namespace SistemaVendas.DAO
{
    public class Conexao
    {
        // Connection string fixa, usada para se conectar ao banco de dados SQL Server
        // IMPORTANTE: Está hardcoded, o que é aceitável em projetos locais, mas idealmente deve vir de um arquivo de configuração em produção.
        // Mudar o "OMEGAMACHINE\SQLEXPRESS" para o nome do seu servidor SQL Server, se necessário.
        private static readonly string connectionString =
            @"Data Source=OMEGAMACHINE\SQLEXPRESS;Initial Catalog=SistemaVendas;Integrated Security=True;";

        // Método utilitário estático que abre e retorna uma conexão pronta para uso
        public static SqlConnection ObterConexao()
        {
            var conexao = new SqlConnection(connectionString);
            conexao.Open(); // Abre imediatamente
            return conexao;
        }

        // Expondo a connection string como propriedade somente leitura
        // Usado por controllers como BackupRestoreController e ImportCsvController
        public static string StringDeConexao => connectionString;
    }
}
