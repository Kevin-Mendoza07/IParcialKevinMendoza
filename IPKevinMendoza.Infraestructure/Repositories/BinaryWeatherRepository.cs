using IPKevinMendoza.Domain.Entitites;
using IPKevinMendoza.Domain.Interfaces;
using IPKevinMendoza.Domain.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Infraestructure.Repositories
{
    public class BinaryWeatherRepository:IWeatherRepository
    {
        private RAFContext context;
        private const int Size = 300;

        public BinaryWeatherRepository()
        {
            context = new RAFContext("Weather",Size);
        }

        public void Create(OpenWeather t)
        {
            WeatherSubModel subModel = WeatherSubModel.MapWeather(t);
            context.Create<WeatherSubModel>(subModel);
        }

        public List<OpenWeather> Read()
        {
            throw new NotImplementedException();
        }

        public List<WeatherSubModel> ReadSubModel()
        {
            return context.GetAll<WeatherSubModel>();
        }
    }
}
