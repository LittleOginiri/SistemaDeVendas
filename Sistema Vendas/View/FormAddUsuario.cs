using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormAddUsuario : Form
    {
        public FormAddUsuario()
        {
            InitializeComponent();

            // Ações dos botões
            btnSalvar.Click += (s, e) => DialogResult = DialogResult.OK;
            btnCancelar.Click += (s, e) => DialogResult = DialogResult.Cancel;

            // Atualiza o campo CPF sempre que o cliente selecionado muda
            cmbClientes.SelectedIndexChanged += (s, e) =>
            {
                if (cmbClientes.SelectedItem is Cliente c)
                    txtCPF.Text = c.CPF;
                else
                    txtCPF.Text = string.Empty;
            };
        }

         
        // Preenche o ComboBox de clientes com lista fornecida.
        // Exibe o nome e associa pelo IdCliente.
         
        public void DefinirClientes(List<Cliente> lista)
        {
            cmbClientes.DataSource = lista;
            cmbClientes.DisplayMember = "Nome";
            cmbClientes.ValueMember = "IdCliente";

            // Exibe o CPF do primeiro cliente da lista automaticamente
            if (lista.Count > 0)
                cmbClientes.SelectedIndex = 0;
        }

         
        // Carrega os dados de um usuário existente nos campos da tela.
         
        public void CarregarUsuario(Usuario u)
        {
            // Define o cliente no combo
            cmbClientes.SelectedValue = u.IdCliente;

            // Preenche os outros campos
            cmbTipoUsuario.SelectedItem = u.TipoUsuario;
            txtLogin.Text = u.Login;
            txtSenha.Text = u.Senha;
        }

         
        // Lê os campos da interface e cria um objeto Usuario com os dados preenchidos.
         
        public Usuario ObterUsuario()
        {
            var cliente = (Cliente)cmbClientes.SelectedItem;

            return new Usuario
            {
                Nome = cliente.Nome,
                IdCliente = cliente.IdCliente,
                Login = txtLogin.Text.Trim(),
                Senha = txtSenha.Text.Trim(),
                TipoUsuario = cmbTipoUsuario.SelectedItem.ToString()
            };
        }

        // Evento vazio, pode ser removido se não estiver sendo usado em outro lugar
        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
