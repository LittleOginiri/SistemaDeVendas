using System;
using System.IO;

namespace SistemaVendas.Utils
{
    public static class Logger
    {
        //  Teoricamente o arquivo de Log ira para a pasta principal do Projeto.
        // IMPORTANTISSIMO!!!: Alterar o destino em que o Log sera criado.
        private static readonly string caminho = Path.Combine(@"C:\Users\vicam\Desktop\Trabalho de Programacao III\SistemaVendas", "log_sistema.txt");


        public static void Registrar(string acao, string usuario)
        {
            try
            {
                var log = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Usuário: {usuario} | Ação: {acao}";
                File.AppendAllText(caminho, log + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Falha silenciosa.
                File.AppendAllText("erro_log.txt", $"[ERRO LOG] {DateTime.Now}: {ex.Message}\n");
            }
        }
    }
}
