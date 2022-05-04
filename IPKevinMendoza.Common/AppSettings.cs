using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Common
{
    public class AppSettings
    {
        public static string ApiUrl { get => ConfigurationManager.AppSettings.Get("ApiUrl"); }
        public static string Token { get => ConfigurationManager.AppSettings.Get("Token"); }
        public static string units { get => ConfigurationManager.AppSettings.Get("Units"); }
        public static string ApiUrlOneCall { get => ConfigurationManager.AppSettings.Get("ApiUrlOneCall"); }
    }
}
