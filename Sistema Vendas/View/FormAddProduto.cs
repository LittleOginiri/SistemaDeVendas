using System;
using System.Windows.Forms;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormAddProduto : Form
    {
        private Produto _produtoExistente;

        // Propriedade pública que representa o produto criado ou editado
        public Produto ProdutoCriado { get; private set; }

        // Construtor padrão para adicionar novo produto
        public FormAddProduto()
        {
            InitializeComponent();
        }

        // Construtor para editar produto existente
        public FormAddProduto(Produto produto) : this()
        {
            _produtoExistente = produto;

            // Preenche os campos com os dados existentes
            lblTitulo.Text = "Editar Produto";
            txtNome.Text = produto.Nome;
            txtDescricao.Text = produto.Descricao;
            txtPreco.Text = produto.Preco.ToString();
            txtEstoque.Text = produto.Estoque.ToString();
        }

        // Lógica do botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação dos campos obrigatórios
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                !decimal.TryParse(txtPreco.Text, out var preco) ||
                !int.TryParse(txtEstoque.Text, out var estoque))
            {
                MessageBox.Show("Verifique Nome, Preço e Estoque.", "Atenção",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_produtoExistente != null)
            {
                // Atualiza os dados do produto existente
                _produtoExistente.Nome = txtNome.Text.Trim();
                _produtoExistente.Descricao = txtDescricao.Text.Trim();
                _produtoExistente.Preco = preco;
                _produtoExistente.Estoque = estoque;
                ProdutoCriado = _produtoExistente;
            }
            else
            {
                // Cria novo produto
                ProdutoCriado = new Produto
                {
                    Nome = txtNome.Text.Trim(),
                    Descricao = txtDescricao.Text.Trim(),
                    Preco = preco,
                    Estoque = estoque
                };
            }

            DialogResult = DialogResult.OK; // Indica sucesso
            Close(); // Fecha o formulário
        }

        // Ação do botão Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close(); // Fecha o formulário sem salvar
        }
    }
}
