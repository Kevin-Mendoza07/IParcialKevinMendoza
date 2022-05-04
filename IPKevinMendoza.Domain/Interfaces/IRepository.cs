using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPKevinMendoza.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T t);
        List<T> Read();   
    }
}
