// View/FormVendas.Designer.cs
namespace SistemaVendas.View
{
    partial class FormVendas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewVendas;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnNovaCompra;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridViewVendas = new System.Windows.Forms.DataGridView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnNovaCompra = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVendas
            // 
            this.dataGridViewVendas.AllowUserToAddRows = false;
            this.dataGridViewVendas.AllowUserToDeleteRows = false;
            this.dataGridViewVendas.ReadOnly = true;
            this.dataGridViewVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVendas.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewVendas.Name = "dataGridViewVendas";
            this.dataGridViewVendas.Size = new System.Drawing.Size(600, 300);
            // removida a linha de CellContentClick que estava gerando erro:
            // this.dataGridViewVendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVendas_CellContentClick);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(10, 320);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(90, 30);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnNovaCompra
            // 
            this.btnNovaCompra.Location = new System.Drawing.Point(110, 320);
            this.btnNovaCompra.Name = "btnNovaCompra";
            this.btnNovaCompra.Size = new System.Drawing.Size(90, 30);
            this.btnNovaCompra.Text = "Nova Compra";
            this.btnNovaCompra.UseVisualStyleBackColor = true;
            this.btnNovaCompra.Click += new System.EventHandler(this.btnNovaCompra_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(210, 320);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(310, 320);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(90, 30);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // FormVendas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 360);
            this.Controls.Add(this.dataGridViewVendas);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnNovaCompra);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcluir);
            this.Name = "FormVendas";
            this.Text = "Vendas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVendas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}