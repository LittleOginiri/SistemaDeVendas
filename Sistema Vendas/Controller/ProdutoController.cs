using System;
using System.Windows.Forms;
using SistemaVendas.View;
using SistemaVendas.DAO;
using SistemaVendas.Model;
using SistemaVendas.Utils; // Importação para uso do Logger

namespace SistemaVendas.Controller
{
    public class ProdutoController
    {
        private readonly FormProdutos _view;
        private readonly ProdutoDAO _dao;

        // Construtor que recebe a view e o DAO
        public ProdutoController(FormProdutos view, ProdutoDAO dao)
        {
            _view = view;
            _dao = dao;

            // Associa os eventos da interface gráfica aos métodos
            _view.OnCarregar += (s, e) => Carregar();
            _view.OnAdicionar += (s, e) => Adicionar();
            _view.OnEditar += (s, e) => Editar();
            _view.OnExcluir += (s, e) => Excluir();

            // Carrega os produtos na inicialização
            Carregar();
        }

        // Recupera todos os produtos do banco e envia para a view
        private void Carregar()
        {
            var lista = _dao.ObterTodos();
            _view.DefinirProdutos(lista);
        }

        // Abre o formulário para adicionar um novo produto
        private void Adicionar()
        {
            using var form = new FormAddProduto();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _dao.Inserir(form.ProdutoCriado);

                // Log de inserção de produto
                Logger.Registrar($"Produto inserido: {form.ProdutoCriado.Nome}", "admin");

                Carregar();
            }
        }

        // Edita o produto selecionado no grid
        private void Editar()
        {
            var sel = _view.ObterProdutoSelecionado();
            if (sel == null)
            {
                MessageBox.Show(
                    "Selecione um produto para editar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var form = new FormAddProduto(sel);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _dao.Atualizar(form.ProdutoCriado);

                // Log de edição de produto
                Logger.Registrar($"Produto editado: {form.ProdutoCriado.Nome} (ID: {form.ProdutoCriado.IdProduto})", "admin");

                Carregar();
            }
        }

        // Exclui o produto selecionado, após confirmação
        private void Excluir()
        {
            var sel = _view.ObterProdutoSelecionado();
            if (sel == null)
            {
                MessageBox.Show(
                    "Selecione um produto para excluir.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var resp = MessageBox.Show(
                $"Deseja realmente excluir “{sel.Nome}”?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                _dao.Excluir(sel.IdProduto);

                // Log de exclusão de produto
                Logger.Registrar($"Produto excluído: {sel.Nome} (ID: {sel.IdProduto})", "admin");

                Carregar();
            }
        }
    }
}
