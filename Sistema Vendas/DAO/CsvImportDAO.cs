using System;
using System.Data.SqlClient;
using System.IO;

namespace SistemaVendas.DAO
{
    public class CsvImportDAO
    {
        private readonly string _connString;

        // Construtor recebe a connection string do banco
        public CsvImportDAO(string connString) => _connString = connString;

        // Importa dados de clientes a partir de um arquivo CSV
        public void ImportClientesFromCsv(string path)
        {
            var lines = File.ReadAllLines(path);
            if (lines.Length <= 1) return; // Ignora arquivos vazios ou apenas com cabeçalho

            using var cn = new SqlConnection(_connString);
            cn.Open();

            // Inicia transação para garantir atomicidade
            using var tran = cn.BeginTransaction();

            using var cmd = new SqlCommand(@"
                INSERT INTO Clientes (nome, cpf, telefone, email)
                 VALUES (@nome, @cpf, @telefone, @email)", cn, tran);

            // Define parâmetros do comando SQL
            cmd.Parameters.Add("@nome", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@cpf", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@telefone", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar);

            try
            {
                // Inicia do índice 1 para pular o cabeçalho
                for (int i = 1; i < lines.Length; i++)
                {
                    var cols = lines[i].Split(',');

                    // Atribui valores aos parâmetros, com fallback para DBNull
                    cmd.Parameters["@nome"].Value = cols.Length > 0 ? cols[0].Trim() : DBNull.Value;
                    cmd.Parameters["@cpf"].Value = cols.Length > 1 ? cols[1].Trim() : DBNull.Value;
                    cmd.Parameters["@telefone"].Value = cols.Length > 2 ? cols[2].Trim() : DBNull.Value;
                    cmd.Parameters["@email"].Value = cols.Length > 3 ? cols[3].Trim() : DBNull.Value;

                    cmd.ExecuteNonQuery(); // Executa a inserção linha por linha
                }

                tran.Commit(); // Confirma todas as inserções
            }
            catch
            {
                tran.Rollback(); // Reverte tudo em caso de erro
                throw; // Repropaga exceção
            }
        }
    }
}
