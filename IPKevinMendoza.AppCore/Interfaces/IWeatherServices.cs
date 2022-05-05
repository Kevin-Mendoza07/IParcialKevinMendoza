using IPKevinMendoza.Domain.Entitites;
using IPKevinMendoza.Domain.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.AppCore.Interfaces
{
    public interface IWeatherServices:IService<OpenWeather>
    {
        List<WeatherSubModel> ReadSubModel();
    }
}
