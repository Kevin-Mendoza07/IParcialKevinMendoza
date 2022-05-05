using IPKevinMendoza.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Domain.SubModel
{
    public class WeatherSubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Temp { get; set; }
        public string Weather { get; set; }
        public string Description { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public double Feels_Like { get; set; }
        public int Pressure { get; set; }
        public int Clouds { get; set; }
        public string Country { get; set; }
        public double Wind_Speed { get; set; }

        public static WeatherSubModel MapWeather(OpenWeather weather)
        {
            if (weather == null)
            {
                throw new ArgumentNullException(nameof(weather));
            }

            WeatherSubModel subModel = new WeatherSubModel()
            {
                Name = weather.Name,
                Temp = weather.Main.Temp,
                Weather = weather.Weather[0].Main,
                Description = weather.Weather[0].Description,
                Temp_Min = weather.Main.Temp_min,
                Temp_Max = weather.Main.Temp_max,
                Feels_Like = weather.Main.Feels_like,
                Pressure = weather.Main.Pressure,
                Clouds = weather.Clouds.All,
                Country = weather.Sys.Country,
                Wind_Speed = weather.Wind.Speed
            };

            return subModel;
        }
    }
}
