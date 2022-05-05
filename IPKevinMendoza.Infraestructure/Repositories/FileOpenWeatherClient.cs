using IPKevinMendoza.Domain.Entitites;
using IPKevinMendoza.Domain.SubModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Infraestructure.Repositories
{
    public class FileOpenWeatherClient
    {
        private static List<WeatherSubModel> data = new List<WeatherSubModel>();
        private string path = Path.GetFullPath("WeatherData.json").Replace(@"\IPKevinMendoza.Presentation\bin\Debug\WeatherData.json", string.Empty) +
            @"\IPKevinMendoza.Infraestructure\Resources\WeatherData.json";
        public FileOpenWeatherClient()
        {
        }
        private void SerializeList()
        {
            string texto = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, texto);

        }

        private void LoadList()
        {
            string texto = File.ReadAllText(path);
            data = JsonConvert.DeserializeObject<List<WeatherSubModel>>(texto);
        }
        public void Create(OpenWeather weather)
        {
            WeatherSubModel subModel = WeatherSubModel.MapWeather(weather);
            subModel.Id = data.Count == 0 ? 1 : data.Count + 1;
            data.Add(subModel);
            SerializeList();
        }

        public List<WeatherSubModel> Read()
        {
            LoadList();
            return data;
        }
    }
}
