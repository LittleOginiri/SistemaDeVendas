using System;
using System.Windows.Forms;
using SistemaVendas.DAO;

namespace SistemaVendas.View
{
    public partial class FormImportCsv : Form
    {
        // Objeto responsável por executar a lógica de importação dos dados do CSV
        private readonly CsvImportDAO _dao;

        // Construtor recebe uma instância do DAO para executar o import
        public FormImportCsv(CsvImportDAO dao)
        {
            _dao = dao;
            InitializeComponent(); // Inicializa os componentes visuais do formulário
        }

        // Ação executada ao clicar no botão "..."
        // Abre diálogo para o usuário selecionar um arquivo CSV
        private void btnBrowseCsv_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "CSV (*.csv)|*.csv", // Filtra apenas arquivos .csv
                Title = "Selecione o arquivo CSV"
            };

            // Se o usuário selecionar um arquivo, exibe o caminho no TextBox
            if (dlg.ShowDialog() == DialogResult.OK)
                txtCsvPath.Text = dlg.FileName;
        }

        // Ação executada ao clicar no botão "Importar"
        private void btnImport_Click(object sender, EventArgs e)
        {
            // Verifica se o caminho do CSV foi preenchido
            if (string.IsNullOrWhiteSpace(txtCsvPath.Text))
            {
                MessageBox.Show("Selecione um arquivo CSV.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tenta importar os dados do arquivo CSV informado
                _dao.ImportClientesFromCsv(txtCsvPath.Text);

                // Mostra mensagem de sucesso
                MessageBox.Show("Importação concluída!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe mensagem com detalhes
                MessageBox.Show($"Erro na importação:\n{ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
