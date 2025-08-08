using System;
using System.Windows.Forms;
using SistemaVendas.View;
using SistemaVendas.DAO;
using SistemaVendas.Model;
using SistemaVendas.Utils; // Importação para uso do Logger

namespace SistemaVendas.Controller
{
    public class ClienteController
    {
        private readonly FormClientes _view;
        private readonly ClienteDAO _dao;
        private readonly int _usuarioLogadoId;

        // Construtor recebe a view, DAO e ID do usuário logado
        public ClienteController(
            FormClientes view,
            ClienteDAO dao,
            int usuarioLogadoId)
        {
            _view = view;
            _dao = dao;
            _usuarioLogadoId = usuarioLogadoId;

            // Associa eventos da interface às funções de CRUD
            _view.OnCarregar += (s, e) => Carregar();
            _view.OnAdicionar += (s, e) => Adicionar();
            _view.OnEditar += (s, e) => Editar();
            _view.OnExcluir += (s, e) => Excluir();

            // Carrega os dados inicialmente
            Carregar();
        }

        // Busca todos os clientes do banco e atualiza a interface
        private void Carregar()
        {
            var lista = _dao.ObterTodos();
            _view.DefinirClientes(lista);
        }

        // Abre formulário de adição de cliente e insere no banco
        private void Adicionar()
        {
            using var form = new FormAddCliente();
            if (form.ShowDialog() != DialogResult.OK) return;

            var novo = form.ClienteCriado;

            // Associa o cliente ao usuário logado
            novo.IdUsuario = _usuarioLogadoId;

            _dao.Inserir(novo);

            // Log de adição de cliente
            Logger.Registrar($"Cliente inserido: {novo.Nome} (CPF: {novo.CPF})", _usuarioLogadoId.ToString());

            Carregar();
        }

        // Abre formulário de edição de cliente selecionado
        private void Editar()
        {
            var sel = _view.ObterClienteSelecionado();
            if (sel == null)
            {
                MessageBox.Show("Selecione um cliente para editar.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new FormAddCliente(sel);
            if (form.ShowDialog() != DialogResult.OK) return;

            var atualizado = form.ClienteCriado;
            atualizado.IdUsuario = _usuarioLogadoId;

            _dao.Atualizar(atualizado);

            // Log de edição de cliente
            Logger.Registrar($"Cliente editado: {atualizado.Nome} (ID: {atualizado.IdCliente})", _usuarioLogadoId.ToString());

            Carregar();
        }

        // Solicita confirmação e exclui cliente selecionado
        private void Excluir()
        {
            var sel = _view.ObterClienteSelecionado();
            if (sel == null)
            {
                MessageBox.Show("Selecione um cliente para excluir.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var msg = $"Excluir cliente “{sel.Nome}” (ID {sel.IdCliente})?";
            if (MessageBox.Show(msg, "Confirmar exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            _dao.Excluir(sel.IdCliente);

            // Log de exclusão de cliente
            Logger.Registrar($"Cliente excluído: {sel.Nome} (ID: {sel.IdCliente})", _usuarioLogadoId.ToString());

            Carregar();
        }
    }
}
