using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVendas.Utils;
using SistemaVendas.DAO;

namespace SistemaVendas.View
{
    public partial class FormPdfReport : Form
    {
        // Dependências DAO para buscar dados
        private readonly ClienteDAO _clienteDao;
        private readonly UsuarioDAO _usuarioDao;
        private readonly ProdutoDAO _produtoDao;
        private readonly VendaDAO _vendaDao;
        private readonly ItemVendaDAO _itemVendaDao;

        // Utilitário para gerar PDFs
        private readonly PdfReportGenerator _pdfGen;

        // Construtor recebe todos os DAOs necessários para compor o relatório
        public FormPdfReport(
            ClienteDAO c, UsuarioDAO u,
            ProdutoDAO p, VendaDAO v,
            ItemVendaDAO iv)
        {
            _clienteDao = c;
            _usuarioDao = u;
            _produtoDao = p;
            _vendaDao = v;
            _itemVendaDao = iv;
            _pdfGen = new PdfReportGenerator(); // instância do gerador de PDF
            InitializeComponent();              // inicialização visual do form
        }

        // Evento de clique para abrir o seletor de local para salvar o PDF
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",   // apenas arquivos PDF
                Title = "Salvar Relatório"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                txtPath.Text = dlg.FileName;    // define o caminho no TextBox
        }

        // Evento de clique para gerar o PDF
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("Selecione um local para salvar o PDF.", "Atenção",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gera o PDF passando os dados de cada DAO convertidos para IEnumerable<object>
                _pdfGen.GenerateAll(
                    _clienteDao.ObterTodos().Cast<object>(),
                    _usuarioDao.ObterTodos().Cast<object>(),
                    _produtoDao.ObterTodos().Cast<object>(),
                    _vendaDao.ObterTodos().Cast<object>(),
                    _itemVendaDao.ObterTodos().Cast<object>(),
                    txtPath.Text
                );
                MessageBox.Show("PDF gerado com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Exibe erro amigável caso algo falhe
                MessageBox.Show($"Falha ao gerar PDF:\n{ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
