using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Infraestructure.Repositories
{
    public class BinaryWeatherRepository
    {
        private RAFContext context;
        private const int Size = 300;

        public BinaryWeatherRepository()
        {
            context = new RAFContext("Weather",Size);
        }

        public void Create()
        {

        }
    }
}
