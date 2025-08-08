using System;
using System.Windows.Forms;
using SistemaVendas.View;
using SistemaVendas.Controller;
using SistemaVendas.DAO;

namespace SistemaVendas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1) Login
            using var loginForm = new FormLogin();
            var loginCtrl = new LoginController(loginForm, new UsuarioDAO());
            Application.Run(loginForm);

            if (loginCtrl.UsuarioLogado == null)
                return; // saiu sem autenticar

            // determina nível de acesso
            bool isAdmin = string.Equals(
                loginCtrl.UsuarioLogado.TipoUsuario,
                "Admin",
                StringComparison.OrdinalIgnoreCase);

            if (isAdmin)
            {
                // 2a) para Admin -> abre o menu principal
                using var menuForm = new FormAdminMenu();
                new AdminMenuController(
                    menuForm,
                    new ClienteDAO(),
                    new ProdutoDAO(),
                    new VendaDAO(),
                    new UsuarioDAO(),
                    loginCtrl.UsuarioLogado.IdUsuario
                );
                Application.Run(menuForm);
            }
            else
            {
                // 2b) para Usuário Comum -> abre direto o CRUD de Vendas
                using var vendasForm = new FormVendas();
                new VendaController(
                    vendasForm,
                    new VendaDAO(),
                    new ProdutoDAO(),
                    new ItemVendaDAO(),
                    new UsuarioDAO(),
                    loginCtrl.UsuarioLogado.IdUsuario,
                    isAdmin: false
                );
                Application.Run(vendasForm);
            }
        }
    }
}
