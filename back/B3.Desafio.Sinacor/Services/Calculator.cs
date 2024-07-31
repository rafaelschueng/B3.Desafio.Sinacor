using B3.Desafio.Sinacor.Controllers.Response;

namespace B3.Desafio.Sinacor.Services
{
    public static class Calculator
    {
        // constants to calculate incomes
        private const float TB = 1.08f;
        private const float CDI = 0.9f;

        // constants to calculate taxes
        private const float HalfYear = 0.225f;
        private const float Year = 0.20f;
        private const float TwoYear = 0.175f;
        private const float MoreThanTwoYears = 0.15f;

        public static decimal CalculateCDI(decimal value)
        {
            return (decimal)((double)value + (1 + CDI * TB));
        }
        public static decimal CalculateCdiTax(decimal value, int month)
        {

            if (month <= 6) return (decimal)((float)value * HalfYear);
            if (month <= 12) return (decimal)((float)value * Year);
            if (month <= 24) return (decimal)((float)value * TwoYear);
            return (decimal)((float)value * MoreThanTwoYears);
        }
        public static IEnumerable<Incomes> CalculateCDIByMonth(decimal value, UInt32 months)
        {
            if (value <= 0) throw new ArgumentException("The 'value' arguments must be greater than 0");

            List<Incomes> CalculatedIncomes = new((int)months);
            for (int i = 0; i < months; i++)
            {
                if (i < 1)
                {
                    decimal income = CalculateCDI(value);
                    decimal tax = CalculateCdiTax(income - value, i);
                    decimal netValue = income - tax;
                    CalculatedIncomes.Add(new Incomes()
                    {
                        Month = DateOnly.FromDateTime(DateTime.Now).AddMonths(i).ToString("dd/MM/yyyy"),
                        Income = income,
                        Tax = tax,
                        NetValue = netValue
                    });
                }
                else
                {
                    decimal income = CalculateCDI(CalculatedIncomes[i - 1].Income);
                    decimal tax = CalculateCdiTax(income - value, i);
                    decimal netValue = income - tax;
                    CalculatedIncomes.Add(new Incomes()
                    {
                        Month = DateOnly.FromDateTime(DateTime.Now).AddMonths(i).ToString("dd/MM/yyyy"),
                        Income = income,
                        Tax = CalculateCdiTax(income - value, i),
                        NetValue = netValue
                    });
                }
            }

            return CalculatedIncomes;
        }
    }
}