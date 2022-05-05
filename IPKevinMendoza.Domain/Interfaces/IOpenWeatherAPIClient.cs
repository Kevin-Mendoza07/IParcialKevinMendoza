using IPKevinMendoza.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Domain.Interfaces
{
    public interface IOpenWeatherAPIClient
    {
        Task<OpenWeather> GetWeatherAsync(string city);
        Task<OneCallAPI> GetOneCallAsync();
    }
}
