namespace SistemaVendas.View
{
    partial class FormItensVenda
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes da interface
        private DataGridView dataGridViewProdutos;    // Tabela com os produtos disponíveis
        private NumericUpDown numQuantidade;          // Campo para escolher a quantidade do produto
        private Button btnAddItem;                    // Botão para adicionar o item à venda
        private Label lblTotalLabel;                  // Label estática "Total:"
        private Label lblTotal;                       // Label dinâmica com o valor total calculado
        private Button btnConfirmar;                  // Botão para confirmar a venda
        private Button btnCancelar;                   // Botão para cancelar a operação

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewProdutos = new DataGridView();
            numQuantidade = new NumericUpDown();
            btnAddItem = new Button();
            lblTotalLabel = new Label();
            lblTotal = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProdutos
            // 
            dataGridViewProdutos.Location = new Point(12, 12);
            dataGridViewProdutos.Name = "dataGridViewProdutos";
            dataGridViewProdutos.ReadOnly = true;
            dataGridViewProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProdutos.Size = new Size(400, 250);
            dataGridViewProdutos.TabIndex = 0;
            // 
            // numQuantidade
            // 
            numQuantidade.Location = new Point(420, 12);
            numQuantidade.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(120, 23);
            numQuantidade.TabIndex = 1;
            numQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(420, 45);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(100, 30);
            btnAddItem.TabIndex = 2;
            btnAddItem.Text = "Adicionar Item";
            btnAddItem.Click += btnAddItem_Click;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Location = new Point(429, 247);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(36, 15);
            lblTotalLabel.TabIndex = 4;
            lblTotalLabel.Text = "Total:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(479, 247);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(28, 15);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "0.00";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(10, 281);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(120, 30);
            btnConfirmar.TabIndex = 6;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(140, 281);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 30);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormItensVenda
            // 
            ClientSize = new Size(548, 329);
            Controls.Add(dataGridViewProdutos);
            Controls.Add(numQuantidade);
            Controls.Add(btnAddItem);
            Controls.Add(lblTotalLabel);
            Controls.Add(lblTotal);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormItensVenda";
            Text = "Nova Compra (Itens)";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
