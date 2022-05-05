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
    public class OpenWeatherAPIClient:IOpenWeatherAPIClient
    {
        private double lat;
        private double lon;
        private long dt;
        private static List<OpenWeather> Weathers=new List<OpenWeather>();
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

                OpenWeather open= JsonConvert.DeserializeObject<OpenWeather>(jsonObject);
                lon = open.Coord.Lon;
                lat=open.Coord.Lat;
                dt = open.Dt;
                Weathers.Add(open);
                return open;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<OneCallAPI> GetOneCallAsync()
        {

            string url = $"{AppSettings.ApiUrlOneCall}lat={lat}&lon={lon}&dt={dt}&appid={ AppSettings.Token}";
            string jsonObject = string.Empty;

            try
            {
                using(HttpClient httpClient = new HttpClient())
                {
                    jsonObject= await httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
                }

                if (string.IsNullOrEmpty(jsonObject))
                {
                    throw new NullReferenceException("El objeto json no puede ser null.");
                }
                OneCallAPI oneCall= JsonConvert.DeserializeObject<OneCallAPI>(jsonObject);
                return oneCall;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

