using Microsoft.Extensions.Configuration;
using System.IO;

namespace LogicLayers.AppConfig
{
    public class AppConfiguration
    {
        private static string _oracleConnectionString;

        public static string OracleConnectionString
        {
            get => GetOracleConnectionString("OracleConnectionString");
        }
        public static string SqlConnectionString
        {
            get => GetOracleConnectionString("SqlServerConnectionString");
        }
        private static string GetOracleConnectionString(string stringName)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var retValue = root.GetSection("ConnectionStrings").GetSection(stringName).Value;
            var appSetting = root.GetSection("ApplicationSettings");
            return retValue;
        }


    }
}