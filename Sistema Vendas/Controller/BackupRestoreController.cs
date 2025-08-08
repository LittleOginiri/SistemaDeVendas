using SistemaVendas.View;
using SistemaVendas.DAO;

namespace SistemaVendas.Controller
{
    public class BackupRestoreController
    {
        // Construtor é responsável por instanciar o DAO de Backup
        // e exibir a interface de backup/restauração como uma janela modal.
        public BackupRestoreController(string connectionString)
        {
            // Injeta a connection string no DAO de Backup
            var dao = new BackupDAO(connectionString);

            // Instancia o formulário de Backup/Restore e passa o DAO
            var form = new FormBackupRestore(dao);

            // Exibe o formulário como diálogo modal (bloqueia a janela anterior)
            form.ShowDialog();
        }
    }
}