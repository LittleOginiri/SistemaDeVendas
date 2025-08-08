using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVendas.View
{
    partial class FormAdminMenu
    {
        private IContainer components = null;

        // Componentes da interface
        private Panel panelMenu;
        private Button btnClientes;
        private Button btnProdutos;
        private Button btnVendas;
        private Button btnUsuarios;
        private Button btnGraficoReceita;
        private Button btnGraficoVendas;
        private Button btnPDF;
        private Button btnBackupRestore;
        private Button btnImportCsv;
        private Label label2;
        private Label label3;
        private Label label1;

        // Método de limpeza de recursos utilizados
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Instanciando componentes
            panelMenu = new Panel();
            btnClientes = new Button();
            btnProdutos = new Button();
            btnVendas = new Button();
            btnUsuarios = new Button();
            btnGraficoReceita = new Button();
            btnGraficoVendas = new Button();
            btnPDF = new Button();
            btnBackupRestore = new Button();
            btnImportCsv = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();

            // Inicia configuração do painel lateral
            panelMenu.SuspendLayout();
            SuspendLayout();

            // Configurações do painel lateral
            panelMenu.BackColor = SystemColors.Control;
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
            panelMenu.Controls.Add(label3);
            panelMenu.Controls.Add(label1);
            panelMenu.Controls.Add(label2);
            panelMenu.Controls.Add(btnClientes);
            panelMenu.Controls.Add(btnProdutos);
            panelMenu.Controls.Add(btnVendas);
            panelMenu.Controls.Add(btnUsuarios);
            panelMenu.Controls.Add(btnGraficoReceita);
            panelMenu.Controls.Add(btnGraficoVendas);
            panelMenu.Controls.Add(btnPDF);
            panelMenu.Controls.Add(btnBackupRestore);
            panelMenu.Controls.Add(btnImportCsv);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 600);
            panelMenu.TabIndex = 0;

            // Botões
            btnClientes.Location = new Point(10, 34);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(180, 30);
            btnClientes.Text = "Clientes";

            btnProdutos.Location = new Point(10, 74);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(180, 30);
            btnProdutos.Text = "Produtos";

            btnVendas.Location = new Point(10, 114);
            btnVendas.Name = "btnVendas";
            btnVendas.Size = new Size(180, 30);
            btnVendas.Text = "Vendas";

            btnUsuarios.Location = new Point(10, 154);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(180, 30);
            btnUsuarios.Text = "Usuários";

            btnGraficoReceita.Location = new Point(10, 245);
            btnGraficoReceita.Name = "btnGraficoReceita";
            btnGraficoReceita.Size = new Size(180, 30);
            btnGraficoReceita.Text = "Gráfico de Receita";
            btnGraficoReceita.Click += btnGraficoReceita_Click;

            btnGraficoVendas.Location = new Point(10, 285);
            btnGraficoVendas.Name = "btnGraficoVendas";
            btnGraficoVendas.Size = new Size(180, 30);
            btnGraficoVendas.Text = "Gráfico por Produto";
            btnGraficoVendas.Click += btnGraficoVendas_Click;

            btnPDF.Location = new Point(10, 323);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(180, 30);
            btnPDF.Text = "PDF";
            btnPDF.Click += btnPDF_Click;

            btnBackupRestore.Location = new Point(10, 441);
            btnBackupRestore.Name = "btnBackupRestore";
            btnBackupRestore.Size = new Size(180, 30);
            btnBackupRestore.Text = "Backup/Restore";
            btnBackupRestore.Click += btnBackupRestore_Click;

            btnImportCsv.Location = new Point(10, 481);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(180, 30);
            btnImportCsv.Text = "Importar CSV";
            btnImportCsv.Click += btnImportCsv_Click;

            // Rótulos de separação por categoria
            label2.AutoSize = true;
            label2.Location = new Point(11, 16);
            label2.Text = "Tabelas";

            label1.AutoSize = true;
            label1.Location = new Point(10, 227);
            label1.Text = "Relatórios e Gráficos";

            label3.AutoSize = true;
            label3.Location = new Point(11, 423);
            label3.Text = "Sistema";

            // Configuração geral do formulário
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(panelMenu);
            IsMdiContainer = true;
            Name = "FormAdminMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu do Administrador";

            // Finalizando inicialização
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}