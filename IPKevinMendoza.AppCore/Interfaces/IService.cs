using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.AppCore.Interfaces
{
    public interface IService<T>
    {
        void Create(T t);
        List<T> Read();
    }
}
