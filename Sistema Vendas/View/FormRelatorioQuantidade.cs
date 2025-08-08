using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Biblioteca para gráficos
using SistemaVendas.DAO;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormRelatorioQuantidade : Form
    {
        private readonly RelatorioDAO _dao; // DAO responsável por buscar dados do relatório

        // Construtor recebe o DAO e inicializa o formulário
        public FormRelatorioQuantidade(RelatorioDAO dao)
        {
            _dao = dao;
            InitializeComponent();

            // Evento que será executado quando o formulário for carregado
            Load += (s, e) =>
            {
                // Busca os produtos no banco
                var produtos = _dao.ObterProdutos().ToList();

                // Preenche o ComboBox com os produtos
                cmbProdutos.DataSource = produtos;
                cmbProdutos.DisplayMember = "Nome"; // Exibe o nome no combo
                cmbProdutos.ValueMember = "IdProduto"; // Usa o ID como valor interno

                // Se houver produtos, seleciona o primeiro automaticamente
                if (produtos.Any())
                    cmbProdutos.SelectedIndex = 0;
            };

            // Evento que ocorre quando o usuário troca a seleção do ComboBox
            cmbProdutos.SelectedIndexChanged += (s, e) =>
            {
                // Verifica se um item está selecionado corretamente
                if (cmbProdutos.SelectedItem is Produto p)
                {
                    // Obtém a quantidade total vendida do produto selecionado
                    int total = _dao.ObterTotalVendidoPorProduto(p.IdProduto);

                    // Acessa a série do gráfico chamada "Quantidade"
                    Series series = chartQuantidade.Series["Quantidade"];

                    // Limpa os dados antigos
                    series.Points.Clear();

                    // Adiciona novo ponto ao gráfico com o nome do produto e quantidade vendida
                    series.Points.AddXY(p.Nome, total);
                }
            };
        }
    }
}
