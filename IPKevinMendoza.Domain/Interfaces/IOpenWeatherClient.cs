using IPKevinMendoza.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Domain.Interfaces
{
    public interface IOpenWeatherClient
    {
        Task<OpenWeather> GetWeatherAsync(string city);
        Task<OneCallAPI> GetOneCallAsync(double lat, double lon, long dt);
    }
}
