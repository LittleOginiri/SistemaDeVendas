using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVendas.View;
using SistemaVendas.DAO;
using SistemaVendas.Model;
using SistemaVendas.Utils; // Importação para uso do Logger

namespace SistemaVendas.Controller
{
    public class UsuarioController
    {
        private readonly FormUsuarios _view;
        private readonly UsuarioDAO _usuarioDao;
        private readonly ClienteDAO _clienteDao;

        // Construtor recebe a view e os DAOs necessários
        public UsuarioController(
            FormUsuarios view,
            UsuarioDAO usuarioDao,
            ClienteDAO clienteDao)
        {
            _view = view;
            _usuarioDao = usuarioDao;
            _clienteDao = clienteDao;

            // Associação dos eventos da interface gráfica com as ações do controller
            _view.OnCarregar += (s, e) => Carregar();
            _view.OnAdicionar += (s, e) => Adicionar();
            _view.OnEditar += (s, e) => Editar();
            _view.OnExcluir += (s, e) => Excluir();

            // Carrega os dados de usuários ao iniciar
            Carregar();
        }

        // Busca todos os usuários no banco e envia para a view
        private void Carregar()
        {
            var lista = _usuarioDao.ObterTodos().ToList();
            _view.DefinirUsuarios(lista);
        }

        // Abre o formulário para cadastrar novo usuário
        private void Adicionar()
        {
            using var f = new FormAddUsuario();

            // Preenche o combo de clientes para associação do usuário
            f.DefinirClientes(_clienteDao.ObterTodos().ToList());

            if (f.ShowDialog() != DialogResult.OK)
                return;

            var u = f.ObterUsuario();
            _usuarioDao.Inserir(u);

            // Log de adição de usuário
            Logger.Registrar($"Usuário inserido: {u.Nome} ({u.TipoUsuario})", u.Login);

            Carregar();
        }

        // Abre o formulário para editar um usuário selecionado
        private void Editar()
        {
            var sel = _view.ObterUsuarioSelecionado();
            if (sel == null)
            {
                MessageBox.Show("Selecione um usuário para editar.");
                return;
            }

            using var f = new FormAddUsuario();
            f.DefinirClientes(_clienteDao.ObterTodos().ToList());

            // Carrega os dados do usuário selecionado no formulário
            f.CarregarUsuario(sel); // ← método auxiliar na View

            if (f.ShowDialog() != DialogResult.OK)
                return;

            var u = f.ObterUsuario();
            u.IdUsuario = sel.IdUsuario; // Garante que o ID original seja mantido

            _usuarioDao.Atualizar(u);

            // Log de edição de usuário
            Logger.Registrar($"Usuário editado: {u.Nome} (ID: {u.IdUsuario})", u.Login);

            Carregar();
        }

        // Exclui o usuário selecionado após confirmação
        private void Excluir()
        {
            var sel = _view.ObterUsuarioSelecionado();
            if (sel == null)
            {
                MessageBox.Show("Selecione um usuário para excluir.");
                return;
            }

            if (MessageBox.Show(
                    $"Excluir usuário {sel.Nome}?",
                    "Confirmação",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _usuarioDao.Excluir(sel.IdUsuario);

            // Log de exclusão de usuário
            Logger.Registrar($"Usuário excluído: {sel.Nome} (ID: {sel.IdUsuario})", sel.Login);

            Carregar();
        }
    }
}
