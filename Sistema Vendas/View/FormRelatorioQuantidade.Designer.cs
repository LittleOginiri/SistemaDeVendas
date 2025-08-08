using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaVendas.View
{
    partial class FormRelatorioQuantidade
    {
        private IContainer components = null;
        private ComboBox cmbProdutos;         // ComboBox para selecionar produtos
        private Chart chartQuantidade;        // Gráfico que mostra a quantidade vendida

        // Liberação de recursos utilizados pelo formulário
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new Container();
            this.cmbProdutos = new ComboBox();
            this.chartQuantidade = new Chart();

            // Criação das áreas e séries do gráfico
            var chartArea1 = new ChartArea();
            var series1 = new Series();

            ((ISupportInitialize)(this.chartQuantidade)).BeginInit();
            this.SuspendLayout();

            // 
            // cmbProdutos
            // 
            this.cmbProdutos.DropDownStyle = ComboBoxStyle.DropDownList; // usuário não pode digitar
            this.cmbProdutos.Location = new Point(12, 12);               // posição na tela
            this.cmbProdutos.Name = "cmbProdutos";
            this.cmbProdutos.Size = new Size(300, 23);                   // tamanho do combo

            // 
            // chartQuantidade
            // 
            chartArea1.Name = "ChartArea1";                              // nome da área do gráfico
            this.chartQuantidade.ChartAreas.Add(chartArea1);             // adiciona a área ao gráfico
            this.chartQuantidade.Dock = DockStyle.Bottom;                // fixa na parte inferior
            this.chartQuantidade.Location = new Point(0, 50);            // começa abaixo do combo
            this.chartQuantidade.Name = "chartQuantidade";
            this.chartQuantidade.Size = new Size(600, 300);              // tamanho do gráfico

            // Configuração da série de dados (barras)
            series1.ChartArea = "ChartArea1";
            series1.Name = "Quantidade";
            series1.ChartType = SeriesChartType.Bar;                     // tipo: barra
            this.chartQuantidade.Series.Add(series1);                    // adiciona a série ao gráfico

            // 
            // FormRelatorioQuantidade
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 360);                        // tamanho total do formulário
            this.Controls.Add(this.cmbProdutos);
            this.Controls.Add(this.chartQuantidade);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;          // janela fixa
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRelatorioQuantidade";
            this.StartPosition = FormStartPosition.CenterParent;         // centraliza na tela
            this.Text = "Total Vendido por Produto";                     // título da janela

            ((ISupportInitialize)(this.chartQuantidade)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
