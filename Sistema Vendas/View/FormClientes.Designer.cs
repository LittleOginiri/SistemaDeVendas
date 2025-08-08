namespace SistemaVendas.View
{
    partial class FormClientes
    {
        // Container de componentes usados no formulário
        private System.ComponentModel.IContainer components = null;

        // Componentes visuais
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;

        // Novos componentes adicionados
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblBusca;

        // Libera recursos utilizados
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Inicializa os componentes do formulário
        private void InitializeComponent()
        {
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();

            // Novos componentes
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblBusca = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewClientes
            this.dataGridViewClientes.Location = new System.Drawing.Point(10, 50);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.Size = new System.Drawing.Size(600, 260);
            this.dataGridViewClientes.ReadOnly = true;
            this.dataGridViewClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // 
            // btnAtualizar
            this.btnAtualizar.Location = new System.Drawing.Point(10, 320);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(80, 30);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);

            // 
            // btnAdicionar
            this.btnAdicionar.Location = new System.Drawing.Point(100, 320);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(80, 30);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);

            // 
            // btnEditar
            this.btnEditar.Location = new System.Drawing.Point(190, 320);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // 
            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(280, 320);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(80, 30);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // 
            // lblBusca
            this.lblBusca.Location = new System.Drawing.Point(10, 15);
            this.lblBusca.Size = new System.Drawing.Size(50, 20);
            this.lblBusca.Text = "Buscar:";

            // 
            // txtBusca
            this.txtBusca.Location = new System.Drawing.Point(65, 12);
            this.txtBusca.Size = new System.Drawing.Size(200, 23);
            this.txtBusca.Name = "txtBusca";

            // 
            // btnBuscar
            this.btnBuscar.Location = new System.Drawing.Point(275, 10);
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.Text = "Filtrar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // 
            // FormClientes
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 360);
            this.Controls.Add(this.lblBusca);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcluir);
            this.Name = "FormClientes";
            this.Text = "Clientes";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
