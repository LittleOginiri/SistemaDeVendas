using System;
using System.Data.SqlClient;
using System.IO;

namespace SistemaVendas.DAO
{
    public class BackupDAO
    {
        private readonly string _connectionString;

        // Construtor recebe a connection string usada para conectar ao banco
        public BackupDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método responsável por realizar o backup do banco de dados
        public void FazerBackup(string backupPath)
        {
            // Extrai o nome do banco da connection string
            var builder = new SqlConnectionStringBuilder(_connectionString);
            var dbName = builder.InitialCatalog;

            // Garante que a pasta de destino exista
            var dir = Path.GetDirectoryName(backupPath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // Comando SQL para fazer o backup do banco no local especificado
            var sql = $"BACKUP DATABASE [{dbName}] TO DISK = @path WITH INIT, FORMAT";

            using var cn = new SqlConnection(_connectionString);
            cn.Open();

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@path", backupPath);
            cmd.ExecuteNonQuery();
        }

        // Método responsável por restaurar o banco a partir de um arquivo .bak
        public void Restaurar(string backupPath)
        {
            // Altera a connection string para usar o banco 'master'
            var builder = new SqlConnectionStringBuilder(_connectionString);
            var dbName = builder.InitialCatalog;
            builder.InitialCatalog = "master";

            using var cn = new SqlConnection(builder.ConnectionString);
            cn.Open();

            // Força o banco em modo SINGLE_USER para permitir restauração
            using (var cmd = new SqlCommand(
                       $"ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", cn))
                cmd.ExecuteNonQuery();

            // Comando para restaurar o banco do arquivo .bak
            using (var cmd = new SqlCommand(
                       $"RESTORE DATABASE [{dbName}] FROM DISK = @path WITH REPLACE", cn))
            {
                cmd.Parameters.AddWithValue("@path", backupPath);
                cmd.ExecuteNonQuery();
            }

            // Retorna o banco ao modo MULTI_USER
            using (var cmd = new SqlCommand(
                       $"ALTER DATABASE [{dbName}] SET MULTI_USER", cn))
                cmd.ExecuteNonQuery();
        }
    }
}
