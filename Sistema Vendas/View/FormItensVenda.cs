using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormItensVenda : Form
    {
        // Armazena o ID do cliente que está realizando a compra
        private readonly int _idCliente;

        // Lista dos itens adicionados à venda
        private readonly List<ItemVenda> _itens = new List<ItemVenda>();

        // Eventos expostos para o controller manipular ações do formulário
        public event EventHandler OnConfirmar;
        public event EventHandler OnCancelar;

        // Propriedades públicas expostas
        public int IdCliente => _idCliente;

        // Soma o valor de todos os itens adicionados
        public decimal ValorTotal => _itens.Sum(i => i.ValorItem);

        // Expõe a lista de itens para o controller
        public IEnumerable<ItemVenda> Itens => _itens;

        // Construtor: recebe os produtos disponíveis e o ID do cliente
        public FormItensVenda(IEnumerable<Produto> produtos, int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();

            // Liga os produtos ao DataGridView de produtos
            dataGridViewProdutos.DataSource = produtos.ToList();

            // Liga a lista de itens ao DataGridView de itens
            // Nao funciounou, removido para gravar o video e ficara assim provavelmente.
            //dataGridViewItens.DataSource = _itens;

            AtualizarTotal(); // Atualiza o valor total da venda
        }

        // Evento do botão "Adicionar Item"
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var linha = dataGridViewProdutos.CurrentRow;
            if (linha == null) return;

            var produto = (Produto)linha.DataBoundItem;
            int qtd = (int)numQuantidade.Value;

            // Valida a quantidade (mínimo 1, máximo o estoque)
            if (qtd < 1 || qtd > produto.Estoque)
            {
                MessageBox.Show(
                  "Quantidade inválida ou maior que o estoque.",
                  "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calcula o valor total do item
            decimal valorItem = produto.Preco * qtd;

            // Cria o item e adiciona à lista
            var item = new ItemVenda
            {
                IdVenda = 0, // será definido no controller
                IdProduto = produto.IdProduto,
                Quantidade = qtd,
                ValorItem = valorItem
            };

            _itens.Add(item);
            // Nao funciounou, removido para gravar o video e ficara assim provavelmente.
            // dataGridViewItens.Refresh(); // Atualiza visualmente a tabela

            // Opcional: reduz estoque localmente para refletir a alteração
            produto.Estoque -= qtd;
            dataGridViewProdutos.Refresh();

            AtualizarTotal(); // Atualiza total exibido
        }

        // Atualiza o label de total com a soma dos valores dos itens
        private void AtualizarTotal()
        {
            lblTotal.Text = ValorTotal.ToString("F2");
        }

        // Evento do botão "Confirmar"
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Valida se há pelo menos 1 item na venda
            if (!_itens.Any())
            {
                MessageBox.Show(
                  "Adicione ao menos um item antes de confirmar.",
                  "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OnConfirmar?.Invoke(this, EventArgs.Empty); // Dispara evento
            this.DialogResult = DialogResult.OK;
            this.Close(); // Fecha o formulário
        }

        // Evento do botão "Cancelar"
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar?.Invoke(this, EventArgs.Empty); // Dispara evento
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Fecha o formulário
        }
    }
}
