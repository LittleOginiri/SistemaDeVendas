using System;
using System.Windows.Forms;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormAddCliente : Form
    {
        private Cliente _clienteExistente;

        // ClienteCriado é a propriedade que armazena o resultado do formulário
        public Cliente ClienteCriado { get; private set; }

        // Construtor usado ao adicionar um novo cliente
        public FormAddCliente()
        {
            InitializeComponent();
        }

        // Construtor usado ao editar um cliente existente
        public FormAddCliente(Cliente cliente) : this()
        {
            _clienteExistente = cliente;

            // Preenche os campos com os dados existentes
            lblTitulo.Text = "Editar Cliente";
            txtNome.Text = cliente.Nome;
            txtCPF.Text = cliente.CPF;
            txtTelefone.Text = cliente.Telefone;
            txtEmail.Text = cliente.Email;

            txtCPF.ReadOnly = true; // CPF não pode ser alterado
        }

        // Ação ao clicar no botão "Salvar"
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação: nome e CPF são obrigatórios
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCPF.Text))
            {
                MessageBox.Show("Nome e CPF são obrigatórios.",
                                "Atenção",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (_clienteExistente != null)
            {
                // Atualiza os dados do cliente existente
                _clienteExistente.Nome = txtNome.Text.Trim();
                _clienteExistente.Telefone = txtTelefone.Text.Trim();
                _clienteExistente.Email = txtEmail.Text.Trim();
                ClienteCriado = _clienteExistente;
            }
            else
            {
                // Cria novo cliente com os dados informados
                ClienteCriado = new Cliente
                {
                    Nome = txtNome.Text.Trim(),
                    CPF = txtCPF.Text.Trim(),
                    Telefone = txtTelefone.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
            }

            DialogResult = DialogResult.OK; // Indica sucesso
            Close(); // Fecha a janela
        }

        // Ação ao clicar no botão "Cancelar"
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close(); // Fecha a janela sem salvar
        }
    }
}
