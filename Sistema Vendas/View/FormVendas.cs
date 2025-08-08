using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormVendas : Form
    {
        // Eventos para ações de interface
        public event EventHandler OnCarregar;
        public event EventHandler OnNovaCompra;
        public event EventHandler OnEditar;
        public event EventHandler OnExcluir;

        // Construtor do formulário
        public FormVendas()
        {
            InitializeComponent();

            // Dispara o carregamento de dados quando o formulário for carregado pela primeira vez
            this.Load += (s, e) => OnCarregar?.Invoke(this, EventArgs.Empty);
        }

         
        // Alimenta a grade com a lista de vendas.
         
        public void DefinirVendas(IEnumerable<Venda> lista)
        {
            dataGridViewVendas.DataSource = lista;
        }

         
        // Retorna a venda atualmente selecionada na grade.
         
        public Venda ObterVendaSelecionada()
        {
            var row = dataGridViewVendas.CurrentRow;
            return row == null
                ? null
                : (Venda)row.DataBoundItem;
        }

         
        // Configura a interface para um usuário comum (não administrador):
        // - Desabilita os botões de editar e excluir
        // - Mantém o botão "Nova Compra" habilitado
        // - Oculta todas as colunas da grade, exceto DataVenda e Valor
         
        public void AjustarParaUsuarioComum()
        {
            // Desabilita ações administrativas
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovaCompra.Enabled = true;

            // Oculta todas as colunas inicialmente
            foreach (DataGridViewColumn col in dataGridViewVendas.Columns)
                col.Visible = false;

            // Exibe apenas as colunas relevantes para o usuário comum
            if (dataGridViewVendas.Columns.Contains("DataVenda"))
                dataGridViewVendas.Columns["DataVenda"].Visible = true;
            if (dataGridViewVendas.Columns.Contains("Valor"))
                dataGridViewVendas.Columns["Valor"].Visible = true;
        }

        // Métodos que respondem aos cliques dos botões (ligados no Designer)

        private void btnAtualizar_Click(object sender, EventArgs e)
            => OnCarregar?.Invoke(this, EventArgs.Empty);

        private void btnNovaCompra_Click(object sender, EventArgs e)
            => OnNovaCompra?.Invoke(this, EventArgs.Empty);

        private void btnEditar_Click(object sender, EventArgs e)
            => OnEditar?.Invoke(this, EventArgs.Empty);

        private void btnExcluir_Click(object sender, EventArgs e)
            => OnExcluir?.Invoke(this, EventArgs.Empty);
    }
}
