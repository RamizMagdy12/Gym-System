namespace GymServices
{
    public sealed record CycleChoice(int Months, string Label);

    public static class BillingCycle
    {
        public static readonly int[] Options = { 1, 3, 6, 12 };

        public static string Label(int months)
        {
            return months switch
            {
                1 => "1 Month",
                3 => "3 Months",
                6 => "6 Months",
                12 => "1 Year",
                _ => $"{months} Months"
            };
        }

        public static DateTime EndDate(DateTime start, int months)
        {
            int safeMonths = months <= 0 ? 1 : months;
            return start.Date.AddMonths(safeMonths);
        }

        public static decimal PriceFor(decimal packagePrice, int packageMonths, int chosenMonths)
        {
            int baseMonths = packageMonths <= 0 ? 1 : packageMonths;
            int months = chosenMonths <= 0 ? baseMonths : chosenMonths;
            return Math.Round(packagePrice / baseMonths * months, 2);
        }
    }
}
