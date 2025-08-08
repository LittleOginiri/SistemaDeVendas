using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SistemaVendas.DAO;
using SistemaVendas.Model;

namespace SistemaVendas.View
{
    public partial class FormRelatorioReceita : Form
    {
        private readonly RelatorioDAO _dao;

        // classe de apoio para popular o ComboBox
        private class ComboItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }

        public FormRelatorioReceita(RelatorioDAO dao)
        {
            _dao = dao;
            InitializeComponent();

            // 1) popula ano e meses imediatamente
            txtAno.Text = DateTime.Now.Year.ToString();
            InicializarCombosDeMes();

            // 2) liga o botão Gerar
            btnGerar.Click += btnGerar_Click;
        }

        private void InicializarCombosDeMes()
        {
            var dtf = CultureInfo.CurrentCulture.DateTimeFormat;
            var lista = new List<ComboItem>();
            for (int m = 1; m <= 12; m++)
            {
                lista.Add(new ComboItem
                {
                    Value = m,
                    Text = dtf.GetMonthName(m)
                });
            }

            // Fonte de dados para ambos os combos
            cmbMesInicio.DataSource = lista.ToList();
            cmbMesInicio.DisplayMember = "Text";
            cmbMesInicio.ValueMember = "Value";
            cmbMesInicio.SelectedIndex = 0;

            cmbMesFim.DataSource = lista.ToList();
            cmbMesFim.DisplayMember = "Text";
            cmbMesFim.ValueMember = "Value";
            cmbMesFim.SelectedIndex = lista.Count - 1;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            // valida ano
            if (!int.TryParse(txtAno.Text, out int ano))
            {
                MessageBox.Show("Digite um ano válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // lê valores selecionados
            int mesIni = (int)cmbMesInicio.SelectedValue;
            int mesFim = (int)cmbMesFim.SelectedValue;

            var dados = _dao.ObterReceitaMensal(ano, mesIni, mesFim).ToList();

            // plota no chart
            var series = chartReceita.Series["Receita"];
            series.Points.Clear();
            foreach (var r in dados)
            {
                string mesAbrev = CultureInfo.CurrentCulture
                    .DateTimeFormat
                    .GetAbbreviatedMonthName(r.Mes);
                series.Points.AddXY(mesAbrev, r.Total);
            }
        }
    }
}
