using System;
using System.Windows.Forms;
using SistemaVendas.View;
using SistemaVendas.DAO;
using SistemaVendas.Model;
using SistemaVendas.Utils; // Importação do utilitário de log

namespace SistemaVendas.Controller
{
    public class LoginController
    {
        private readonly FormLogin _view;
        private readonly UsuarioDAO _usuarioDao;

        // Propriedade pública para armazenar o usuário autenticado
        public Usuario UsuarioLogado { get; private set; }

        // Construtor associa evento do botão "Entrar" à lógica de login
        public LoginController(FormLogin view, UsuarioDAO usuarioDao)
        {
            _view = view;
            _usuarioDao = usuarioDao;

            // Associa o evento da view à função de login
            _view.OnEntrar += (s, e) => Entrar();
        }

        // Realiza a autenticação do usuário
        private void Entrar()
        {
            // Obtém login e senha informados pela interface
            var (login, senha) = _view.ObterCredenciais();

            // Valida usuário no banco de dados
            UsuarioLogado = _usuarioDao.ValidarLogin(login, senha);

            if (UsuarioLogado == null)
            {
                // Mostra mensagem de erro se falha na autenticação
                MessageBox.Show(
                    "Login ou senha inválidos.",
                    "Erro de Autenticação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Registra a ação de login no arquivo de log
            Logger.Registrar("Login efetuado com sucesso", UsuarioLogado.Login);

            // Fecha a janela de login após sucesso
            _view.Close();
        }
    }
}
