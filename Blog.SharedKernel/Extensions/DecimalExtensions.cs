namespace TgaCase.SharedKernel.Extensions
{
    public static class DecimalExtensions 
    {
        public static string ToTurkishCurrency(this decimal str)
        {
            return str.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-TR"));
        }
    }
}