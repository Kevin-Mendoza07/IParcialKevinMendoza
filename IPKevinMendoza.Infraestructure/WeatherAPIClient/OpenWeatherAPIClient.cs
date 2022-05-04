using IPKevinMendoza.Common;
using IPKevinMendoza.Domain.Entitites;
using IPKevinMendoza.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Infraestructure.WeatherAPIClient
{
    public class OpenWeatherAPIClient:IOpenWeatherClient
    {
        public async Task<OpenWeather> GetWeatherAsync(string city)
        {

            string url = $"{AppSettings.ApiUrl}{city}&units={AppSettings.units}&lang=sp&appid={AppSettings.Token}";
            string jsonObject = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    jsonObject = await httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
                }

                if (string.IsNullOrEmpty(jsonObject))
                {
                    throw new NullReferenceException("El objeto json no puede ser null.");
                }

                return JsonConvert.DeserializeObject<OpenWeather>(jsonObject);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<OneCallAPI> GetOneCallAsync(double lat, double lon, long dt)
        {
            return null;
        }
    }
}

