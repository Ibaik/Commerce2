using System.Globalization;

namespace E_Commerce2.Localization
{
    public class Cultures
    {
        public static string DefaultCulture => "en";

        public static CultureInfo[] SupporterCultures => new CultureInfo[]
            {
                new CultureInfo("en"),
                new CultureInfo("tr"),
                new CultureInfo("ar"),
                new CultureInfo("zh")
            };
    }
}
