using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVendas.View
{
    partial class FormBackupRestore
    {
        private IContainer components = null;
        private Label lblBackup;           // Rótulo "Backup"
        private TextBox txtBackupPath;     // Caminho para salvar o arquivo .bak
        private Button btnBrowseBackup;    // Botão para abrir o diálogo de salvar arquivo
        private Button btnBackup;          // Botão que executa o backup
        private Label lblRestore;          // Rótulo "Restore"
        private TextBox txtRestorePath;    // Caminho do arquivo .bak para restaurar
        private Button btnBrowseRestore;   // Botão para abrir o diálogo de abrir arquivo
        private Button btnRestore;         // Botão que executa o restore

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Instancia os componentes
            this.lblBackup = new Label();
            this.txtBackupPath = new TextBox();
            this.btnBrowseBackup = new Button();
            this.btnBackup = new Button();
            this.lblRestore = new Label();
            this.txtRestorePath = new TextBox();
            this.btnBrowseRestore = new Button();
            this.btnRestore = new Button();
            this.SuspendLayout();

            // lblBackup - Rótulo do campo de backup
            this.lblBackup.AutoSize = true;
            this.lblBackup.Location = new Point(12, 15);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new Size(92, 15);
            this.lblBackup.Text = "Backup (salvar em):";

            // txtBackupPath - Mostra o caminho escolhido para o arquivo .bak
            this.txtBackupPath.Location = new Point(110, 12);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new Size(350, 23);

            // btnBrowseBackup - Abre o dialog para salvar arquivo
            this.btnBrowseBackup.Location = new Point(470, 11);
            this.btnBrowseBackup.Name = "btnBrowseBackup";
            this.btnBrowseBackup.Size = new Size(30, 23);
            this.btnBrowseBackup.Text = "...";
            this.btnBrowseBackup.UseVisualStyleBackColor = true;
            this.btnBrowseBackup.Click += new System.EventHandler(this.btnBrowseBackup_Click);

            // btnBackup - Executa o backup
            this.btnBackup.Location = new Point(510, 11);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new Size(75, 23);
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);

            // lblRestore - Rótulo do campo de restauração
            this.lblRestore.AutoSize = true;
            this.lblRestore.Location = new Point(12, 50);
            this.lblRestore.Name = "lblRestore";
            this.lblRestore.Size = new Size(98, 15);
            this.lblRestore.Text = "Restore (arquivo):";

            // txtRestorePath - Mostra o caminho do arquivo .bak a ser restaurado
            this.txtRestorePath.Location = new Point(110, 47);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.ReadOnly = true;
            this.txtRestorePath.Size = new Size(350, 23);

            // btnBrowseRestore - Abre o dialog para selecionar arquivo a restaurar
            this.btnBrowseRestore.Location = new Point(470, 46);
            this.btnBrowseRestore.Name = "btnBrowseRestore";
            this.btnBrowseRestore.Size = new Size(30, 23);
            this.btnBrowseRestore.Text = "...";
            this.btnBrowseRestore.UseVisualStyleBackColor = true;
            this.btnBrowseRestore.Click += new System.EventHandler(this.btnBrowseRestore_Click);

            // btnRestore - Executa a restauração
            this.btnRestore.Location = new Point(510, 47);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new Size(75, 23);
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);

            // Configuração geral do formulário
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 90);
            this.Controls.Add(this.lblBackup);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.btnBrowseBackup);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.lblRestore);
            this.Controls.Add(this.txtRestorePath);
            this.Controls.Add(this.btnBrowseRestore);
            this.Controls.Add(this.btnRestore);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBackupRestore";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Backup & Restore";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
