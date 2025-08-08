using System;
using System.Windows.Forms;

namespace SistemaVendas.View
{
    public partial class FormLogin : Form
    {
        // Evento público que será disparado ao clicar no botão "Entrar"
        public event EventHandler OnEntrar;

        // Construtor do formulário
        public FormLogin()
        {
            InitializeComponent();
        }

        // Método chamado quando o botão "Entrar" é clicado
        // Dispara o evento OnEntrar, que pode ser tratado externamente
        private void btnEntrar_Click(object sender, EventArgs e)
            => OnEntrar?.Invoke(this, EventArgs.Empty);

        // Método utilitário que retorna as credenciais digitadas pelo usuário
        // Retorna uma tupla com login e senha
        public (string login, string senha) ObterCredenciais()
            => (txtLogin.Text.Trim(), txtSenha.Text.Trim());
    }
}
