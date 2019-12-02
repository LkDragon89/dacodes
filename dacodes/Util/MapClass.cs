using System;
using System.Collections.Generic;
using System.Reflection;

namespace dacodes.Util
{
    /// <summary>
    /// Se encarga del mapeo de datos de un objeto en especifico
    /// </summary>
    /// <typeparam name="T">Representa el tipo de objeto que se mapea</typeparam>
    public class MapClass<T>
    {

        private PropertyInfo[] propInfos;
        /// <summary>
        /// Iniciaciliza los valores por defecto de la clase
        /// </summary>
        public MapClass()
        {

        }
        /// <summary>
        /// Mapero del objeto con sus propiedades y valores
        /// </summary>
        /// <param name="t">Objeto que se mapea</param>
        /// <returns>Retorna un objeto de tipo dictionary</returns>
        public Dictionary<string, object> MappingClass(T t)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            Type typeObject = t.GetType();
            propInfos = typeObject.GetProperties();
            foreach (PropertyInfo infObject in propInfos)
            {
                dictionary.Add(infObject.Name, infObject.GetValue(t));
            }
            return dictionary;
        }

        /// <summary>
        /// Mapero del objeto con sus propiedades y valores
        /// </summary>
        /// <param name="t">Objeto que se mapea</param>
        /// <returns>Retorna un objeto de tipo dictionary</returns>
        public Dictionary<string, object> MappingClass(object t)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            Type typeObject = t.GetType();
            propInfos = typeObject.GetProperties();
            foreach (PropertyInfo infObject in propInfos)
            {
                dictionary.Add(infObject.Name, infObject.GetValue(t));
            }
            return dictionary;
        }

        public object GetValue(object value)
        {
            Type type = value.GetType();
            var field = Activator.CreateInstance(type);
            var values = MappingObject(value);

            foreach (var t in values)
            {
                type.GetProperty(t.Key).SetValue(field, t.Value);
            }

            return field;
        }

        public object GetValue(Dictionary<string, object> dictionary, object value)
        {
            Type type = value.GetType();
            var field = Activator.CreateInstance(type);

            foreach (var t in dictionary)
            {
                type.GetProperty(t.Key).SetValue(field, t.Value);
            }

            return field;
        }

        private Dictionary<string, object> MappingObject(object t)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            Type typeObject = t.GetType();
            propInfos = typeObject.GetProperties();
            foreach (PropertyInfo infObject in propInfos)
            {
                dictionary.Add(infObject.Name, infObject.GetValue(t));
            }
            return dictionary;
        }
    }
}