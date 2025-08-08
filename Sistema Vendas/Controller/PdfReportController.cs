using SistemaVendas.DAO;
using SistemaVendas.View;

namespace SistemaVendas.Controller
{
    public class PdfReportController
    {
        // Construtor recebe todos os DAOs necessários para gerar relatórios em PDF
        public PdfReportController(
            ClienteDAO c, UsuarioDAO u,
            ProdutoDAO p, VendaDAO v,
            ItemVendaDAO iv)
        {
            // Cria e exibe o formulário de geração de relatórios em PDF
            var form = new FormPdfReport(c, u, p, v, iv);

            // Abre a janela como modal (bloqueia a janela anterior até ser fechado)
            form.ShowDialog();
        }
    }
}
