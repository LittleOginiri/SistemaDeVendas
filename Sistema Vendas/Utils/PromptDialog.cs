using System.Windows.Forms;

namespace SistemaVendas.Util
{
    public static class PromptDialog
    {

        // Exibe uma caixa de diálogo com uma Label, um TextBox e um botão OK.
        // Retorna o texto digitado, ou null se o usuário cancelar.

        public static string Show(string text, string caption)
        {
            // Criação do formulário com tamanho fixo e centralizado
            var prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent
            };

            // Label com o texto de instrução
            var lbl = new Label()
            {
                Left = 10,
                Top = 10,
                Text = text,
                AutoSize = true
            };

            // Caixa de texto para entrada do usuário
            var txt = new TextBox()
            {
                Left = 10,
                Top = lbl.Bottom + 25,
                Width = 260
            };

            // Botão OK para confirmar a entrada
            var ok = new Button()
            {
                Text = "OK",
                Left = 200,
                Width = 70,
                Top = txt.Bottom + 10,
                DialogResult = DialogResult.OK
            };

            // Adiciona controles ao formulário
            prompt.Controls.Add(lbl);
            prompt.Controls.Add(txt);
            prompt.Controls.Add(ok);
            prompt.AcceptButton = ok; // Enter ativa o botão OK

            // Exibe o formulário e retorna o valor digitado, se confirmado
            return prompt.ShowDialog() == DialogResult.OK
                ? txt.Text
                : null;
        }
    }
}
