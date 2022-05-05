using IPKevinMendoza.Domain.Entitites;
using IPKevinMendoza.Domain.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Domain.Interfaces
{
    public interface IWeatherRepository:IRepository<OpenWeather>
    {
        List<WeatherSubModel> ReadSubModel();
    }
}
