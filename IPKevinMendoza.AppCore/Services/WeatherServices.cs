using IPKevinMendoza.AppCore.Interfaces;
using IPKevinMendoza.Domain.Entitites;
using IPKevinMendoza.Domain.Interfaces;
using IPKevinMendoza.Domain.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.AppCore.Services
{
    public class WeatherServices:IWeatherServices
    {
        private IWeatherRepository repository;
        public WeatherServices(IWeatherRepository repository)
        {
            this.repository = repository;
        }
        public void Create(OpenWeather t)
        {
            repository.Create(t);
        }

        public List<OpenWeather> Read()
        {
            return repository.Read();
        }

        public List<WeatherSubModel> ReadSubModel()
        {
            return repository.ReadSubModel();
        }
    }
}
