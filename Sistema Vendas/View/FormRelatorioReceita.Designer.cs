using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaVendas.View
{
    partial class FormRelatorioReceita
    {
        private IContainer components = null;
        private Label lblAno;
        private TextBox txtAno;
        private Label lblMesInicio;
        private ComboBox cmbMesInicio;
        private Label lblMesFim;
        private ComboBox cmbMesFim;
        private Button btnGerar;
        private Chart chartReceita;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAno = new Label();
            this.txtAno = new TextBox();
            this.lblMesInicio = new Label();
            this.cmbMesInicio = new ComboBox();
            this.lblMesFim = new Label();
            this.cmbMesFim = new ComboBox();
            this.btnGerar = new Button();
            this.chartReceita = new Chart();
            var chartArea1 = new ChartArea();
            var series1 = new Series();

            ((ISupportInitialize)(this.chartReceita)).BeginInit();
            this.SuspendLayout();

            // Label para "Ano"
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new Point(12, 15);
            this.lblAno.Text = "Ano:";

            // Campo de texto para digitar o ano
            this.txtAno.Location = new Point(50, 12);
            this.txtAno.Size = new Size(80, 23);

            // Label "Mês Início"
            this.lblMesInicio.AutoSize = true;
            this.lblMesInicio.Location = new Point(150, 15);
            this.lblMesInicio.Text = "Mês Início:";

            // ComboBox para selecionar o mês de início
            this.cmbMesInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMesInicio.Location = new Point(230, 12);
            this.cmbMesInicio.Size = new Size(100, 23);

            // Label "Mês Fim"
            this.lblMesFim.AutoSize = true;
            this.lblMesFim.Location = new Point(350, 15);
            this.lblMesFim.Text = "Mês Fim:";

            // ComboBox para selecionar o mês final
            this.cmbMesFim.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMesFim.Location = new Point(410, 12);
            this.cmbMesFim.Size = new Size(100, 23);

            // Botão para gerar o gráfico
            this.btnGerar.Location = new Point(530, 10);
            this.btnGerar.Size = new Size(80, 26);
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);

            // Gráfico de Receita
            chartArea1.Name = "ChartArea1"; // área do gráfico
            this.chartReceita.ChartAreas.Add(chartArea1);
            this.chartReceita.Dock = DockStyle.Bottom; // fixa na parte inferior do formulário
            this.chartReceita.Location = new Point(0, 50);
            this.chartReceita.Size = new Size(800, 400);

            series1.ChartArea = "ChartArea1";
            series1.Name = "Receita";
            series1.ChartType = SeriesChartType.Line; // tipo do gráfico: linha
            this.chartReceita.Series.Add(series1);

            // Configurações do Formulário principal
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.lblMesInicio);
            this.Controls.Add(this.cmbMesInicio);
            this.Controls.Add(this.lblMesFim);
            this.Controls.Add(this.cmbMesFim);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.chartReceita);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "FormRelatorioReceita";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Receita ao Longo do Tempo";

            ((ISupportInitialize)(this.chartReceita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
