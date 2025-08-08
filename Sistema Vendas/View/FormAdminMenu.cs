using System;
using System.Windows.Forms;

namespace SistemaVendas.View
{
    public partial class FormAdminMenu : Form
    {
        // Eventos públicos que serão vinculados a ações nos botões
        public event EventHandler OnClientes;
        public event EventHandler OnProdutos;
        public event EventHandler OnVendas;
        public event EventHandler OnUsuarios;
        public event EventHandler OnGraficoReceita;
        public event EventHandler OnGraficoVendas;
        public event EventHandler OnGraficos;
        public event EventHandler OnPDF;
        public event EventHandler OnBackupRestore;
        public event EventHandler OnImportCsv;

        // Construtor
        public FormAdminMenu()
        {
            InitializeComponent(); // Carrega os componentes visuais

            // Associa os eventos de clique dos botões aos respectivos eventos públicos
            btnClientes.Click += (s, e) => OnClientes?.Invoke(this, e);
            btnProdutos.Click += (s, e) => OnProdutos?.Invoke(this, e);
            btnVendas.Click += (s, e) => OnVendas?.Invoke(this, e);
            btnUsuarios.Click += (s, e) => OnUsuarios?.Invoke(this, e);
            btnGraficoReceita.Click += (s, e) => OnGraficoReceita?.Invoke(this, e);
            btnGraficoVendas.Click += (s, e) => OnGraficoVendas?.Invoke(this, e);
            // Este botão está comentado, mas mantém o padrão para futura implementação
            // Ele esta comentando por que estava no designer para mostrar o grafico, depois eu troquei ele com outros.
            // btnGraficos.Click += (s, e) => OnGraficos?.Invoke(this, e);
            btnPDF.Click += (s, e) => OnPDF?.Invoke(this, e);
            btnBackupRestore.Click += (s, e) => OnBackupRestore?.Invoke(this, e);
            btnImportCsv.Click += (s, e) => OnImportCsv?.Invoke(this, e);
        }

        // Métodos stub exigidos pelo Designer (para evitar erros na interface visual)
        private void btnGraficoReceita_Click(object sender, EventArgs e) { }
        private void btnGraficoVendas_Click(object sender, EventArgs e) { }
        private void btnGraficos_Click(object sender, EventArgs e) { }
        private void btnPDF_Click(object sender, EventArgs e) { }
        private void btnBackupRestore_Click(object sender, EventArgs e) { }
        private void btnImportCsv_Click(object sender, EventArgs e) { }

        // Evento genérico para clique em label (usado no designer para evitar warnings)
        private void label1_Click(object sender, EventArgs e) { }
    }
}
