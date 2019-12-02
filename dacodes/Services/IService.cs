using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.Services
{
    public interface IService<T>
    {
        T Save(T t);

        void Edit(T t);

        void Delete(int id);

        T Get(int id);

        List<T> Get(T t);

        bool Exist(T t);
    }
}
