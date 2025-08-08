using SistemaVendas.DAO;
using SistemaVendas.View;

namespace SistemaVendas.Controller
{
    public class ImportCsvController
    {
        // Construtor é responsável por instanciar o DAO de importação CSV
        // e exibir o formulário responsável por permitir o envio de arquivos CSV
        public ImportCsvController(string connectionString)
        {
            // Instancia o DAO responsável por importar dados a partir de arquivos CSV
            var dao = new CsvImportDAO(connectionString);

            // Instancia o formulário de importação, passando o DAO
            var form = new FormImportCsv(dao);

            // Exibe o formulário de forma modal (bloqueando interação com a janela anterior)
            form.ShowDialog();
        }
    }
}
