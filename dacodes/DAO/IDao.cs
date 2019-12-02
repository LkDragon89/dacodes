using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.DAO
{
    public interface IDao<T>
    {
        int Insert(T t);

        void Update(T t);

        void Delete(int id);

        List<T> Select(T t);

        T Select(int id);
    }
}
