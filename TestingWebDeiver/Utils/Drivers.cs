using DocumentFormat.OpenXml.Spreadsheet;
using Lucene.Net.Support;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestingWebDeiver.Utils
{
    public static class Drivers
    {
        static IConfiguration _configuration;

        static Drivers()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\polza\source\repos\TestingWebDeiver\TestingWebDeiver\appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
        public static IWebDriver GetDriver()
        {
            var driverName = _configuration["driver"];
            var cookies = _configuration["cookes"];

            Console.WriteLine("----driver----");
            Console.WriteLine(driverName);
            Console.WriteLine("----driver----");
            switch (driverName)
            {
                case "chrome":
                    {
                        var options = new ChromeOptions();
                        /*options.AddArgument("headless")*/;
                        if(cookies == "disable")
                        {
                            options.AddUserProfilePreference("profile.default_content_settings_values.cookies", 1);
                            options.AddUserProfilePreference("profile.cookie_controls_mode", 1);
                        }
                        return new ChromeDriver(@"C:\BSTU\3k\drivers", options);
                    }
                    break;
                case "edge":
                    {

                    }
                    break;
            }
            return null;
        }
    }
}
