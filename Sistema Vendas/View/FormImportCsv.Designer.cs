using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVendas.View
{
    partial class FormImportCsv
    {
        // Container de componentes usado pelo Windows Forms
        private IContainer components = null;

        // Controles visuais do formulário
        private Label lblArquivo;
        private TextBox txtCsvPath;
        private Button btnBrowseCsv;
        private Button btnImport;

        // Libera recursos utilizados
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Inicialização dos componentes do formulário
        private void InitializeComponent()
        {
            // Label: "Arquivo CSV"
            this.lblArquivo = new Label();
            this.lblArquivo.AutoSize = true;
            this.lblArquivo.Location = new Point(12, 15);
            this.lblArquivo.Text = "Arquivo CSV:";

            // TextBox: Caminho do arquivo selecionado
            this.txtCsvPath = new TextBox();
            this.txtCsvPath.Location = new Point(90, 12);
            this.txtCsvPath.Size = new Size(350, 23);
            this.txtCsvPath.ReadOnly = true; // Usuário não pode digitar manualmente

            // Botão "...": Abre caixa de seleção de arquivo
            this.btnBrowseCsv = new Button();
            this.btnBrowseCsv.Location = new Point(450, 11);
            this.btnBrowseCsv.Size = new Size(30, 23);
            this.btnBrowseCsv.Text = "...";
            this.btnBrowseCsv.UseVisualStyleBackColor = true;
            this.btnBrowseCsv.Click += new System.EventHandler(this.btnBrowseCsv_Click); // Evento associado

            // Botão "Importar": Executa a importação do CSV
            this.btnImport = new Button();
            this.btnImport.Location = new Point(490, 11);
            this.btnImport.Size = new Size(75, 23);
            this.btnImport.Text = "Importar";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click); // Evento associado

            // Configurações gerais do Formulário
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(580, 50); // Tamanho fixo
            this.Controls.Add(this.lblArquivo);
            this.Controls.Add(this.txtCsvPath);
            this.Controls.Add(this.btnBrowseCsv);
            this.Controls.Add(this.btnImport);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImportCsv";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Importar CSV - Clientes"; // Título do formulário
            this.ResumeLayout(false);
            this.PerformLayout(); // Necessário para que os controles apareçam corretamente
        }
    }
}
