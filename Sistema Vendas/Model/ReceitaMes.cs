namespace SistemaVendas.Model
{
    public class ReceitaMes
    {
        // Número do mês (1 = Janeiro, 12 = Dezembro)
        public int Mes { get; set; }

        // Valor total da receita no mês
        public decimal Total { get; set; }

        // Propriedade calculada que retorna o nome do mês em texto (de acordo com a cultura atual)
        public string NomeMes
            => System.Globalization.CultureInfo
                  .CurrentCulture
                  .DateTimeFormat
                  .GetMonthName(Mes);
    }
}
