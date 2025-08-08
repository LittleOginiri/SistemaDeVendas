using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVendas.DAO;
using SistemaVendas.Model;
using SistemaVendas.View;
using SistemaVendas.Util;
using SistemaVendas.Utils; // Importação para usar o Logger

namespace SistemaVendas.Controller
{
    public class VendaController
    {
        private readonly FormVendas _view;
        private readonly VendaDAO _vendaDao;
        private readonly ProdutoDAO _produtoDao;
        private readonly ItemVendaDAO _itemVendaDao;
        private readonly UsuarioDAO _usuarioDao;
        private readonly int _usuarioLogadoId;
        private readonly bool _isAdmin;

        // Construtor que injeta dependências e configura eventos da view
        public VendaController(
            FormVendas view,
            VendaDAO vendaDao,
            ProdutoDAO produtoDao,
            ItemVendaDAO itemVendaDao,
            UsuarioDAO usuarioDao,
            int usuarioLogadoId,
            bool isAdmin)
        {
            _view = view;
            _vendaDao = vendaDao;
            _produtoDao = produtoDao;
            _itemVendaDao = itemVendaDao;
            _usuarioDao = usuarioDao;
            _usuarioLogadoId = usuarioLogadoId;
            _isAdmin = isAdmin;

            _view.OnCarregar += (s, e) => Carregar();
            _view.OnNovaCompra += (s, e) => NovaCompra();
            _view.OnEditar += (s, e) => Editar();
            _view.OnExcluir += (s, e) => Excluir();

            // Ajusta permissões de interface para usuário comum
            if (!_isAdmin)
                _view.AjustarParaUsuarioComum();
        }

        // Carrega as vendas do banco: todas se admin, senão apenas do usuário
        private void Carregar()
        {
            var lista = _isAdmin
                ? _vendaDao.ObterTodos()
                : _vendaDao.ObterPorUsuario(_usuarioLogadoId);
            _view.DefinirVendas(lista);
        }

        // Inicia processo de nova compra (venda)
        private void NovaCompra()
        {
            // Obtém o ID do cliente vinculado ao usuário logado
            int idCliente = _usuarioDao.ObterPorId(_usuarioLogadoId).IdCliente;

            // Abre o formulário de seleção de itens para a venda
            var formItens = new FormItensVenda(
                _produtoDao.ObterTodos(),
                idCliente
            );

            if (formItens.ShowDialog() != DialogResult.OK) return;

            // Cria novo registro de venda com total calculado
            var venda = new Venda
            {
                IdUsuario = _usuarioLogadoId,
                DataVenda = DateTime.Now,
                Total = formItens.ValorTotal
            };

            // Insere a venda e captura o ID gerado
            int idVenda = _vendaDao.Inserir(venda);

            // Insere os itens vendidos e reduz o estoque
            foreach (var item in formItens.Itens)
            {
                _itemVendaDao.Inserir(
                    idVenda,
                    item.IdProduto,
                    item.Quantidade,
                    item.ValorItem
                );

                // Atualiza o estoque no banco
                _produtoDao.ReduzirEstoque(item.IdProduto, item.Quantidade);
            }

            // Log de nova venda
            Logger.Registrar($"Nova venda registrada - ID: {idVenda}, Total: {venda.Total:C}", _usuarioLogadoId.ToString());

            // Atualiza a lista de vendas
            Carregar();
        }

        // Permite edição dos dados da venda (data e total)
        private void Editar()
        {
            var venda = _view.ObterVendaSelecionada();
            if (venda == null)
            {
                MessageBox.Show("Selecione uma venda para editar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1) Pede nova data para a venda
            var novaDataStr = PromptDialog.Show(
                $"Data atual: {venda.DataVenda:dd/MM/yyyy HH:mm}\n\nDigite nova data e hora (YYYY-MM-DD HH:MM):",
                "Editar Data da Venda");

            if (string.IsNullOrWhiteSpace(novaDataStr) ||
                !DateTime.TryParse(novaDataStr, out var novaData))
                return;

            venda.DataVenda = novaData;

            // 2) Pede novo valor total
            var novoTotalStr = PromptDialog.Show(
                $"Total atual: {venda.Total:F2}\n\nDigite novo total:",
                "Editar Valor da Venda");

            if (string.IsNullOrWhiteSpace(novoTotalStr) ||
                !decimal.TryParse(novoTotalStr, out var novoTotal))
                return;

            venda.Total = novoTotal;

            // 3) Aplica a alteração no banco
            _vendaDao.Atualizar(venda);

            // Log de edição de venda
            Logger.Registrar($"Venda editada - ID: {venda.IdVenda}, Nova Data: {venda.DataVenda}, Novo Total: {venda.Total:C}", _usuarioLogadoId.ToString());

            // 4) Atualiza visualização
            Carregar();
        }

        // Remove uma venda selecionada, com confirmação
        private void Excluir()
        {
            var venda = _view.ObterVendaSelecionada();
            if (venda == null)
            {
                MessageBox.Show("Selecione uma venda para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resp = MessageBox.Show(
                $"Deseja realmente excluir a venda #{venda.IdVenda}?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            _vendaDao.Excluir(venda.IdVenda);

            // Log de exclusão de venda
            Logger.Registrar($"Venda excluída - ID: {venda.IdVenda}", _usuarioLogadoId.ToString());

            Carregar();
        }
    }
}
