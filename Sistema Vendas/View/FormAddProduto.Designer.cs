namespace SistemaVendas.View
{
    partial class FormAddProduto
    {
        private System.ComponentModel.IContainer components = null;

        // Controles do formulário
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label lblEstoque;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;

        // Liberação de recursos
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Inicialização dos componentes e layout do formulário
        private void InitializeComponent()
        {
            // Título
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Text = "Cadastrar Produto";

            // Nome
            this.lblNome = new System.Windows.Forms.Label();
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 50);
            this.lblNome.Text = "Nome*";

            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtNome.Location = new System.Drawing.Point(100, 47);
            this.txtNome.Size = new System.Drawing.Size(250, 23);

            // Descrição
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(20, 90);
            this.lblDescricao.Text = "Descrição";

            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtDescricao.Location = new System.Drawing.Point(100, 87);
            this.txtDescricao.Size = new System.Drawing.Size(250, 23);

            // Preço
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(20, 130);
            this.lblPreco.Text = "Preço*";

            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtPreco.Location = new System.Drawing.Point(100, 127);
            this.txtPreco.Size = new System.Drawing.Size(100, 23);

            // Estoque
            this.lblEstoque = new System.Windows.Forms.Label();
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Location = new System.Drawing.Point(220, 130);
            this.lblEstoque.Text = "Estoque*";

            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.txtEstoque.Location = new System.Drawing.Point(280, 127);
            this.txtEstoque.Size = new System.Drawing.Size(70, 23);

            // Botão Salvar
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSalvar.Location = new System.Drawing.Point(100, 170);
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // Botão Cancelar
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCancelar.Location = new System.Drawing.Point(230, 170);
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Configurações gerais do formulário
            this.ClientSize = new System.Drawing.Size(380, 220);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.lblEstoque);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAddProduto";
            this.Text = "Novo Produto";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
