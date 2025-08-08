namespace SistemaVendas.View
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        // Controles visuais usados no formulário
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnEntrar;

        // Libera recursos utilizados pelos componentes
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Método responsável por inicializar todos os componentes do formulário
        private void InitializeComponent()
        {
            // Label para o campo "Login"
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(20, 20);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(40, 15);
            this.lblLogin.Text = "Login:";

            // TextBox para entrada do login
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtLogin.Location = new System.Drawing.Point(80, 17);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(200, 23);

            // Label para o campo "Senha"
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(20, 60);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(44, 15);
            this.lblSenha.Text = "Senha:";

            // TextBox para entrada da senha
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtSenha.Location = new System.Drawing.Point(80, 57);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(200, 23);
            this.txtSenha.UseSystemPasswordChar = true; // oculta os caracteres da senha

            // Botão para submeter o login
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnEntrar.Location = new System.Drawing.Point(80, 100);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(100, 30);
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);

            // Propriedades gerais do formulário
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnEntrar);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout(); // necessário para layout correto
        }
    }
}
