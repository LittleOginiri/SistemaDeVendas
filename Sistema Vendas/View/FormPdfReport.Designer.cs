using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVendas.View
{
    partial class FormPdfReport
    {
        private IContainer components = null;
        private TextBox txtPath;
        private Button btnBrowse;
        private Button btnGenerate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Campo de texto onde o caminho do arquivo será exibido
            this.txtPath = new TextBox();
            // Botão para abrir o diálogo de seleção de caminho
            this.btnBrowse = new Button();
            // Botão para gerar o PDF
            this.btnGenerate = new Button();

            this.SuspendLayout();

            // 
            // txtPath
            // 
            this.txtPath.Location = new Point(12, 15);     // posição no form
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;                  // impede edição manual
            this.txtPath.Size = new Size(400, 23);         // largura e altura do campo

            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new Point(420, 14);  // à direita do campo de texto
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new Size(30, 23);
            this.btnBrowse.Text = "...";                  // botão para navegar até arquivo
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click); // evento de clique

            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new Point(460, 14); // à direita do botão de navegação
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new Size(100, 23);
            this.btnGenerate.Text = "Gerar PDF";          // botão que executa a geração do relatório
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click); // evento de clique

            // 
            // FormPdfReport
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(580, 50);            // tamanho fixo da janela
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // janela fixa
            this.MaximizeBox = false;                      // desabilita botão de maximizar
            this.MinimizeBox = false;                      // desabilita botão de minimizar
            this.Name = "FormPdfReport";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Gerar Relatório PDF";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
