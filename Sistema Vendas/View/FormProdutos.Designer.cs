// Arquivo Designer responsável pela construção da interface gráfica do formulário de produtos
namespace SistemaVendas.View
{
    partial class FormProdutos
    {
        // Container para os componentes da interface
        private System.ComponentModel.IContainer components = null;

        // Declaração dos controles da interface
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;

        // Liberação de recursos alocados
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Inicialização dos componentes visuais
        private void InitializeComponent()
        {
            // Criação e configuração da DataGridView
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();

            // Inicializa o componente DataGridView
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false; // Usuário não pode adicionar linhas diretamente
            this.dataGridView1.AllowUserToDeleteRows = false; // Nem remover
            this.dataGridView1.ReadOnly = true; // Apenas leitura
            this.dataGridView1.Location = new System.Drawing.Point(10, 10); // Posição
            this.dataGridView1.Name = "dataGridView1"; // Nome do controle
            this.dataGridView1.Size = new System.Drawing.Size(480, 200); // Tamanho
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // Seleção de linha inteira

            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(10, 220);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(90, 30);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click); // Evento de clique

            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(110, 220);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(90, 30);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);

            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(210, 220);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(310, 220);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(90, 30);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // 
            // FormProdutos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 260); // Tamanho da janela
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcluir);
            this.Name = "FormProdutos"; // Nome do formulário
            this.Text = "Produtos"; // Título da janela

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false); // Finaliza layout sem controles sobrepostos
        }
    }
}
