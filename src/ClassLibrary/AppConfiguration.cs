using Microsoft.Extensions.Configuration;
using System.IO;

namespace LogicLayers.AppConfig
{
    public class AppConfiguration
    {
        private static string _oracleConnectionString;

        public static string OracleConnectionString
        {
            get => GetOracleConnectionString();
        }

        private static string GetOracleConnectionString()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var retValue = root.GetSection("ConnectionStrings").GetSection("OracleConnectionString").Value;
            var appSetting = root.GetSection("ApplicationSettings");
            return retValue;
        }


    }
}