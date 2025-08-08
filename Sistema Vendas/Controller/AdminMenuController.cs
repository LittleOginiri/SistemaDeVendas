using SistemaVendas.DAO;
using SistemaVendas.View;

namespace SistemaVendas.Controller
{
    public class AdminMenuController
    {
        private readonly FormAdminMenu _view;
        private readonly ClienteDAO _clienteDao;
        private readonly ProdutoDAO _produtoDao;
        private readonly VendaDAO _vendaDao;
        private readonly UsuarioDAO _usuarioDao;
        private readonly int _usuarioLogadoId;

        // Construtor recebe a view principal e DAOs necessários
        public AdminMenuController(
            FormAdminMenu view,
            ClienteDAO clienteDao,
            ProdutoDAO produtoDao,
            VendaDAO vendaDao,
            UsuarioDAO usuarioDao,
            int usuarioLogadoId)
        {
            _view = view;
            _clienteDao = clienteDao;
            _produtoDao = produtoDao;
            _vendaDao = vendaDao;
            _usuarioDao = usuarioDao;
            _usuarioLogadoId = usuarioLogadoId;

            // Ativa o modo MDI no formulário principal
            _view.IsMdiContainer = true;

            // Associa eventos de botões do menu às respectivas funções
            _view.OnClientes += (s, e) => AbrirCRUDClientes();
            _view.OnProdutos += (s, e) => AbrirCRUDProdutos();
            _view.OnVendas += (s, e) => AbrirCRUDVendas();
            _view.OnUsuarios += (s, e) => AbrirCRUDUsuarios();

            // Eventos de geração de gráficos
            _view.OnGraficoReceita += (s, e) => new RelatorioReceitaController();

            // OBSERVAÇÃO: Os dois próximos gráficos instanciam o mesmo controller.
            // Verifique se é desejado ou se há duplicidade.
            _view.OnGraficoVendas += (s, e) => new RelatorioQuantidadeController(); // <- possível duplicata
            //_view.OnGraficos += (s, e) => new RelatorioQuantidadeController();      // <- possível duplicata (duplicata)

            // Evento para geração de PDFs de todas as tabelas
            _view.OnPDF += (s, e) =>
                new PdfReportController(
                    _clienteDao,
                    _usuarioDao,
                    _produtoDao,
                    _vendaDao,
                    new ItemVendaDAO()
                );

            // Evento para realizar backup e restauração do banco de dados
            _view.OnBackupRestore += (s, e) =>
                new BackupRestoreController(Conexao.StringDeConexao);

            // Evento para importar dados de um CSV
            _view.OnImportCsv += (s, e) =>
                new ImportCsvController(Conexao.StringDeConexao);
        }

        // Abertura da interface CRUD de Clientes
        private void AbrirCRUDClientes()
        {
            var form = new FormClientes();
            new ClienteController(form, _clienteDao, _usuarioLogadoId);
            AbrirComoFilho(form);
        }

        // Abertura da interface CRUD de Produtos
        private void AbrirCRUDProdutos()
        {
            var form = new FormProdutos();
            new ProdutoController(form, _produtoDao);
            AbrirComoFilho(form);
        }

        // Abertura da interface CRUD de Vendas (modo Admin)
        private void AbrirCRUDVendas()
        {
            var form = new FormVendas();
            new VendaController(
                form,
                _vendaDao,
                _produtoDao,
                new ItemVendaDAO(),
                _usuarioDao,
                _usuarioLogadoId,
                isAdmin: true
            );
            AbrirComoFilho(form);
        }

        // Abertura da interface CRUD de Usuários
        private void AbrirCRUDUsuarios()
        {
            var form = new FormUsuarios();
            new UsuarioController(form, _usuarioDao, _clienteDao);
            AbrirComoFilho(form);
        }

        // Método utilitário para abrir formulários como janelas filhas (MDI)
        private void AbrirComoFilho(System.Windows.Forms.Form form)
        {
            form.MdiParent = _view;
            form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            form.Show();
        }
    }
}
