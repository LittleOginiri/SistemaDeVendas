using SistemaVendas.DAO;
using SistemaVendas.View;

namespace SistemaVendas.Controller
{
    public class RelatorioQuantidadeController
    {
        // Construtor responsável por gerar o gráfico de quantidade de vendas/produtos
        public RelatorioQuantidadeController()
        {
            // Instancia o DAO que fornece os dados do relatório
            var dao = new RelatorioDAO();

            // Cria o formulário que exibe o gráfico com base nos dados do DAO
            var form = new FormRelatorioQuantidade(dao);

            // Exibe o formulário como diálogo modal (bloqueando interação com a janela anterior)
            form.ShowDialog();
        }
    }
}
