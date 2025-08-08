namespace SistemaVendas.View
{
    partial class FormAddUsuario
    {
        private System.ComponentModel.IContainer components = null;

        // Controles da interface do formulário
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.ComboBox cmbTipoUsuario;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTitulo;

        // Libera recursos utilizados pelo formulário
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Método que configura todos os controles do formulário
        private void InitializeComponent()
        {
            // Label do campo Nome
            lblNome = new Label();
            lblNome.AutoSize = true;
            lblNome.Location = new Point(12, 59);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(48, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome*:";

            // ComboBox para seleção de clientes existentes
            cmbClientes = new ComboBox();
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.Location = new Point(120, 56);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(250, 23);
            cmbClientes.TabIndex = 1;

            // Label para o CPF
            lblCPF = new Label();
            lblCPF.AutoSize = true;
            lblCPF.Location = new Point(12, 94);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(31, 15);
            lblCPF.TabIndex = 2;
            lblCPF.Text = "CPF:";

            // TextBox do CPF (somente leitura)
            txtCPF = new TextBox();
            txtCPF.Location = new Point(120, 91);
            txtCPF.Name = "txtCPF";
            txtCPF.ReadOnly = true;
            txtCPF.Size = new Size(250, 23);
            txtCPF.TabIndex = 3;

            // Label para o tipo de usuário
            lblTipoUsuario = new Label();
            lblTipoUsuario.AutoSize = true;
            lblTipoUsuario.Location = new Point(12, 129);
            lblTipoUsuario.Name = "lblTipoUsuario";
            lblTipoUsuario.Size = new Size(82, 15);
            lblTipoUsuario.TabIndex = 4;
            lblTipoUsuario.Text = "Tipo Usuário*:";

            // ComboBox para selecionar tipo do usuário
            cmbTipoUsuario = new ComboBox();
            cmbTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoUsuario.Items.AddRange(new object[] { "Admin", "Comum" });
            cmbTipoUsuario.Location = new Point(120, 126);
            cmbTipoUsuario.Name = "cmbTipoUsuario";
            cmbTipoUsuario.Size = new Size(121, 23);
            cmbTipoUsuario.TabIndex = 5;

            // Label para o login
            lblLogin = new Label();
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(12, 164);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(45, 15);
            lblLogin.TabIndex = 6;
            lblLogin.Text = "Login*:";

            // TextBox para o login
            txtLogin = new TextBox();
            txtLogin.Location = new Point(120, 161);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 23);
            txtLogin.TabIndex = 7;

            // Label para senha
            lblSenha = new Label();
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(12, 199);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(47, 15);
            lblSenha.TabIndex = 8;
            lblSenha.Text = "Senha*:";

            // TextBox para senha (ocultando o texto)
            txtSenha = new TextBox();
            txtSenha.Location = new Point(120, 196);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(250, 23);
            txtSenha.TabIndex = 9;

            // Botão de salvar
            btnSalvar = new Button();
            btnSalvar.Location = new Point(120, 234);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(80, 30);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;

            // Botão de cancelar
            btnCancelar = new Button();
            btnCancelar.Location = new Point(210, 234);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 30);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;

            // Título do formulário
            lblTitulo = new Label();
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(145, 21);
            lblTitulo.TabIndex = 12;
            lblTitulo.Text = "Cadastrar Usuário";
            lblTitulo.Click += lblTitulo_Click;

            // Configurações do próprio formulário
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 289);
            Controls.Add(lblTitulo);
            Controls.Add(lblNome);
            Controls.Add(cmbClientes);
            Controls.Add(lblCPF);
            Controls.Add(txtCPF);
            Controls.Add(lblTipoUsuario);
            Controls.Add(cmbTipoUsuario);
            Controls.Add(lblLogin);
            Controls.Add(txtLogin);
            Controls.Add(lblSenha);
            Controls.Add(txtSenha);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAddUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastrar/Editar Usuário";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
