using SistemaVendas.DAO;             // <<--- necessário para acessar o DAO de relatórios
using SistemaVendas.View;            // <<--- necessário para exibir o formulário da view

namespace SistemaVendas.Controller
{
    public class RelatorioReceitaController
    {
        // Construtor responsável por exibir o gráfico de receita
        public RelatorioReceitaController()
        {
            // Cria uma instância do DAO que provê os dados de receita
            var dao = new RelatorioDAO();

            // Cria o formulário que exibirá o gráfico de receita com base nos dados do DAO
            var form = new FormRelatorioReceita(dao);

            // Exibe o formulário como janela modal (bloqueia até fechar)
            form.ShowDialog();
        }
    }
}
