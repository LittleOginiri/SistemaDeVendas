namespace SistemaVendas.View
{
    partial class FormAddCliente
    {
        private System.ComponentModel.IContainer components = null;

        // Controles da interface
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;

        // Libera os recursos do formulário
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Inicializa todos os componentes do formulário
        private void InitializeComponent()
        {
            // Label principal (título)
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Text = "Cadastrar Novo Cliente";

            // Label e textbox para Nome
            this.lblNome = new System.Windows.Forms.Label();
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 50);
            this.lblNome.Text = "Nome*";

            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtNome.Location = new System.Drawing.Point(100, 47);
            this.txtNome.Size = new System.Drawing.Size(200, 23);

            // Label e textbox para CPF
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(20, 90);
            this.lblCPF.Text = "CPF*";

            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtCPF.Location = new System.Drawing.Point(100, 87);
            this.txtCPF.Size = new System.Drawing.Size(200, 23);

            // Label e textbox para Telefone
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(20, 130);
            this.lblTelefone.Text = "Telefone";

            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtTelefone.Location = new System.Drawing.Point(100, 127);
            this.txtTelefone.Size = new System.Drawing.Size(200, 23);

            // Label e textbox para Email
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 170);
            this.lblEmail.Text = "Email";

            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEmail.Location = new System.Drawing.Point(100, 167);
            this.txtEmail.Size = new System.Drawing.Size(200, 23);

            // Botão "Salvar"
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSalvar.Location = new System.Drawing.Point(60, 210);
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // Botão "Cancelar"
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCancelar.Location = new System.Drawing.Point(180, 210);
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Configurações finais do Form
            this.ClientSize = new System.Drawing.Size(330, 260);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAddCliente";
            this.Text = "Novo Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
