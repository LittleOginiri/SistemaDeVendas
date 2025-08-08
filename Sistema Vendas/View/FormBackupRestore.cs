using System;
using System.Windows.Forms;
using SistemaVendas.DAO;

namespace SistemaVendas.View
{
    public partial class FormBackupRestore : Form
    {
        // DAO responsável por executar os comandos de backup e restore no banco de dados
        private readonly BackupDAO _dao;

        // Construtor recebe a instância do DAO
        public FormBackupRestore(BackupDAO dao)
        {
            _dao = dao;
            InitializeComponent(); // Inicializa os componentes da interface
        }

        // Evento ao clicar no botão de seleção de caminho para salvar backup
        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "Backup (*.bak)|*.bak",      // Define extensão do arquivo .bak
                Title = "Salvar Backup"
            };

            // Se usuário confirmar o caminho, define no TextBox
            if (dlg.ShowDialog() == DialogResult.OK)
                txtBackupPath.Text = dlg.FileName;
        }

        // Evento ao clicar no botão de realizar o backup
        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                _dao.FazerBackup(txtBackupPath.Text);  // Executa o método de backup com caminho fornecido
                MessageBox.Show("Backup concluído!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mostra mensagem de erro em caso de falha
                MessageBox.Show($"Erro ao fazer backup:\n{ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ao clicar no botão para selecionar um arquivo .bak para restauração
        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "Backup (*.bak)|*.bak",      // Filtro apenas para arquivos .bak
                Title = "Selecionar arquivo de Backup"
            };

            // Define o caminho do arquivo no TextBox
            if (dlg.ShowDialog() == DialogResult.OK)
                txtRestorePath.Text = dlg.FileName;
        }

        // Evento ao clicar no botão de restaurar o backup
        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                _dao.Restaurar(txtRestorePath.Text); // Executa a restauração
                MessageBox.Show("Restauração concluída!\nReabra a aplicação.", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mostra erro caso aconteça algo durante a restauração
                MessageBox.Show($"Erro ao restaurar:\n{ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
