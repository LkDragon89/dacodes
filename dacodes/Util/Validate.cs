using System;
using System.Collections.Generic;
using System.Linq;

namespace dacodes.Util
{
    public class Validate<T>
    {
        private MapClass<T> mapClass;

        public Validate()
        {
            mapClass = new MapClass<T>();
        }

        public T CopyToModel(object Origin)
        {
            try
            {
                Type type = typeof(T);
                T Destinity = (T)Activator.CreateInstance(type);

                //Mapea los valores de los objetos a comparar
                Dictionary<string, object> vModel = mapClass.MappingClass(Origin);
                Dictionary<string, object> vDAO = mapClass.MappingClass(Destinity);

                for (int indexT = 0; indexT < vModel.Count; indexT++)
                {
                    var _fieldT = vModel.ElementAt(indexT);
                    for (int indexS = 0; indexS < vDAO.Count; indexS++)
                    {
                        var _fieldS = vDAO.ElementAt(indexS);
                        if (_fieldT.Key.Equals(_fieldS.Key))
                        {
                            vDAO[_fieldS.Key] = _fieldT.Value;
                        }
                    }
                }

                Destinity = (T)mapClass.GetValue(vDAO, Destinity);

                return Destinity;
            }
            catch
            {
                throw;
            }
        }
    }
}