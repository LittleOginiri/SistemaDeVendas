using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormUsuarios : Form
    {
        // Eventos públicos que serão utilizados por controllers externos
        public event EventHandler OnCarregar;   // disparado ao clicar em "Atualizar"
        public event EventHandler OnAdicionar;  // disparado ao clicar em "Adicionar"
        public event EventHandler OnEditar;     // disparado ao clicar em "Editar"
        public event EventHandler OnExcluir;    // disparado ao clicar em "Excluir"

        public FormUsuarios()
        {
            InitializeComponent(); // inicializa os componentes visuais
        }

        // Métodos conectados via Designer para disparar os eventos acima
        private void btnAtualizar_Click(object sender, EventArgs e)
            => OnCarregar?.Invoke(this, EventArgs.Empty); // dispara o evento OnCarregar

        private void btnAdicionar_Click(object sender, EventArgs e)
            => OnAdicionar?.Invoke(this, EventArgs.Empty); // dispara o evento OnAdicionar

        private void btnEditar_Click(object sender, EventArgs e)
            => OnEditar?.Invoke(this, EventArgs.Empty); // dispara o evento OnEditar

        private void btnExcluir_Click(object sender, EventArgs e)
            => OnExcluir?.Invoke(this, EventArgs.Empty); // dispara o evento OnExcluir

         
        // Popula a grade com a lista de usuários
         
        public void DefinirUsuarios(IEnumerable<Usuario> lista)
        {
            // Converte para lista e define como fonte de dados da grade
            dataGridViewUsuarios.DataSource = lista.ToList();
        }

         
        // Retorna o usuário selecionado ou null se nada estiver selecionado
         
        public Usuario ObterUsuarioSelecionado()
        {
            var row = dataGridViewUsuarios.CurrentRow;
            return row == null ? null : (Usuario)row.DataBoundItem; // retorna o objeto vinculado à linha atual
        }
    }
}
