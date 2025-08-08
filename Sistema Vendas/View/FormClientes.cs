// View/FormClientes.cs
using System;
using System.Collections.Generic;
using System.Drawing; // Adicionado para customizar cores
using System.Linq;
using System.Windows.Forms;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormClientes : Form
    {
        // Eventos públicos para delegar ações
        public event EventHandler OnCarregar;   // Chamado ao clicar em "Atualizar"
        public event EventHandler OnAdicionar;  // Chamado ao clicar em "Adicionar"
        public event EventHandler OnEditar;     // Chamado ao clicar em "Editar"
        public event EventHandler OnExcluir;    // Chamado ao clicar em "Excluir"

        private List<Cliente> _clientesFiltrados = new List<Cliente>();

        // Construtor
        public FormClientes()
        {
            InitializeComponent(); // Inicializa os componentes do formulário

            // Aplica estilo visual ao DataGridView
            dataGridViewClientes.EnableHeadersVisualStyles = false;
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewClientes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewClientes.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        // Evento do botão Atualizar -> dispara o evento OnCarregar
        private void btnAtualizar_Click(object sender, EventArgs e)
            => OnCarregar?.Invoke(this, EventArgs.Empty);

        // Evento do botão Adicionar -> dispara o evento OnAdicionar
        private void btnAdicionar_Click(object sender, EventArgs e)
            => OnAdicionar?.Invoke(this, EventArgs.Empty);

        // Evento do botão Editar -> dispara o evento OnEditar
        private void btnEditar_Click(object sender, EventArgs e)
            => OnEditar?.Invoke(this, EventArgs.Empty);

        // Evento do botão Excluir -> dispara o evento OnExcluir
        private void btnExcluir_Click(object sender, EventArgs e)
            => OnExcluir?.Invoke(this, EventArgs.Empty);

        // Método público para preencher a DataGridView com a lista de clientes
        public void DefinirClientes(IEnumerable<Cliente> lista)
        {
            _clientesFiltrados = lista.ToList();
            dataGridViewClientes.DataSource = _clientesFiltrados;
            foreach (DataGridViewColumn col in dataGridViewClientes.Columns)
                col.SortMode = DataGridViewColumnSortMode.Automatic;
        }

        // Retorna o cliente atualmente selecionado na DataGridView
        public Cliente ObterClienteSelecionado()
            => dataGridViewClientes.CurrentRow == null
                ? null
                : (Cliente)dataGridViewClientes.CurrentRow.DataBoundItem;

        // Evento do botão de busca de cliente por nome
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string termo = txtBusca.Text.Trim().ToLower();
            var filtrado = _clientesFiltrados
                .Where(c => c.Nome.ToLower().Contains(termo))
                .ToList();
            dataGridViewClientes.DataSource = filtrado;
        }
    }
}
