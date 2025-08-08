using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormProdutos : Form
    {
        // Eventos públicos que podem ser assinados externamente para tratar ações do formulário
        public event EventHandler OnCarregar;
        public event EventHandler OnAdicionar;
        public event EventHandler OnEditar;
        public event EventHandler OnExcluir;

        // Construtor padrão do formulário
        public FormProdutos()
        {
            InitializeComponent(); // Inicializa os componentes visuais
        }

        // Define a fonte de dados da DataGridView com uma lista de produtos
        public void DefinirProdutos(IEnumerable<Produto> lista)
            => dataGridView1.DataSource = lista.ToList();

        // Retorna o produto atualmente selecionado na grade (linha ativa)
        public Produto ObterProdutoSelecionado()
        {
            if (dataGridView1.CurrentRow == null) return null; // Nenhuma linha selecionada
            return (Produto)dataGridView1.CurrentRow.DataBoundItem; // Retorna o objeto vinculado
        }

        // Manipuladores de eventos para os botões da interface, que disparam eventos para os controladores

        private void btnAtualizar_Click(object sender, EventArgs e)
            => OnCarregar?.Invoke(this, EventArgs.Empty); // Dispara evento OnCarregar

        private void btnAdicionar_Click(object sender, EventArgs e)
            => OnAdicionar?.Invoke(this, EventArgs.Empty); // Dispara evento OnAdicionar

        private void btnEditar_Click(object sender, EventArgs e)
            => OnEditar?.Invoke(this, EventArgs.Empty); // Dispara evento OnEditar

        private void btnExcluir_Click(object sender, EventArgs e)
            => OnExcluir?.Invoke(this, EventArgs.Empty); // Dispara evento OnExcluir
    }
}
