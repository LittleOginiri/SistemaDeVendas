using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace SistemaVendas.Utils
{
    public class PdfReportGenerator
    {
        // Fontes utilizadas nos títulos, subtítulos e texto
        private readonly XFont _headerFont = new XFont("Verdana", 16, XFontStyle.Bold);
        private readonly XFont _subFont = new XFont("Verdana", 12, XFontStyle.Bold);
        private readonly XFont _textFont = new XFont("Verdana", 10, XFontStyle.Regular);

        private const double MARGIN = 40;

         
        // Gera um relatório em PDF contendo seções para cada tipo de dado.
         
        public void GenerateAll(
            IEnumerable<object> clientes,
            IEnumerable<object> usuarios,
            IEnumerable<object> produtos,
            IEnumerable<object> vendas,
            IEnumerable<object> itensVendas,
            string outputPath)
        {
            var doc = new PdfDocument();

            // Adiciona seções no documento para cada entidade
            AddSection(doc, "Clientes", clientes);
            AddSection(doc, "Usuários", usuarios);
            AddSection(doc, "Produtos", produtos);
            AddSection(doc, "Vendas", vendas);
            AddSection(doc, "ItensVendas", itensVendas);

            // Salva o arquivo PDF final
            doc.Save(outputPath);
        }

         
        // Adiciona uma nova página com os dados de uma seção.
         
        private void AddSection(PdfDocument doc, string title, IEnumerable<object> items)
        {
            var page = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            double y = MARGIN;

            // Título da seção
            gfx.DrawString(title, _headerFont, XBrushes.Black,
                new XRect(MARGIN, y, page.Width - 2 * MARGIN, 30), XStringFormats.TopLeft);
            y += 30;

            var list = items.ToList();
            if (!list.Any()) return;

            // Cabeçalho com os nomes das propriedades
            var props = list.First().GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var header = string.Join(" | ", props.Select(p => p.Name));
            gfx.DrawString(header, _subFont, XBrushes.DarkBlue,
                new XRect(MARGIN, y, page.Width - 2 * MARGIN, 20), XStringFormats.TopLeft);
            y += 25;

            // Cada linha de dados dos objetos
            foreach (var obj in list)
            {
                var values = props.Select(p =>
                {
                    var v = p.GetValue(obj);
                    return v?.ToString() ?? "";
                });

                var line = string.Join(" | ", values);

                gfx.DrawString(line, _textFont, XBrushes.Black,
                    new XRect(MARGIN, y, page.Width - 2 * MARGIN, 15), XStringFormats.TopLeft);

                y += 18;

                // Se passar da altura da página, cria nova
                if (y > page.Height - MARGIN)
                {
                    page = doc.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = MARGIN;
                }
            }
        }
    }
}
