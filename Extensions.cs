using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using D2Sym.D2O;
using D2Sym.Classes;

namespace D2Sym
{
    public static class Extensions
    {
        public static void Load()
        {
            D2OActivator.OpenD2Os("C:/D2O/", "C:/lang.d2i", true);

            var monsters = D2OActivator.GetD2OValues<Monster>();

            foreach (var monster in monsters)
            {
                int id = monster.id;
                var spells = monster.spells;
            }




           var queriesData = D2OSynchroniser.GetSyncQueries<Monster>(true);

           foreach (var query in queriesData.Queries)
           {
               // SQLConnection.ExecuteNonQuery(query);
           }
        }
        public static bool HasAttribute(this Type type, Type attributeType)
        {
            return type.GetCustomAttribute(attributeType) != null;
        }
       
        public static bool IsEnumerable(this object obj)
        {
            return obj.GetType().GetInterfaces().Contains(typeof(IEnumerable));
        }
       
        public static string ToSplitedString(this IList list)
        {
            string str = string.Empty;
            foreach (var value in list)
            {
                str += value.ToString() + ",";
            }
            str = str.Remove(str.Length - 1);
            return str;
        }
       
        public static List<T> ToSplitedList<T>(this string str, char separator = ',')
        {
            var list = new List<T>();
            foreach (var value in str.Split(separator))
            {
                list.Add((T)Convert.ChangeType(value, typeof(T)));
            }
            return list;
        }
        public static bool ScramEqualList<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first.Count() != second.Count())
                return false;
            int i = 0;
            foreach (var data in first)
            {
                if (!second.ElementAt(i).Equals(data))
                    return false;
                i++;
            }
            return true;
        }
        public static bool ScramEqualDictionary<T, T2>(this Dictionary<T, T2> first, Dictionary<T, T2> second)
        {
            if (first.Count != second.Count)
                return false;
            foreach (var data in first)
            {
                if (second.ContainsKey(data.Key))
                {
                    var value = second.First(x => x.Key.Equals(data.Key));
                    if (!value.Value.Equals(data.Value))
                        return false;
                }
                else
                    return false;
            }
            return true;
        }
        public static string AsIpString(this IPEndPoint endpoint)
        {
            return endpoint.Address + ":" + endpoint.Port;
        }
        public static bool HasInterface(this Type type, Type interfaceType)
        {
            return type.FindInterfaces(new TypeFilter(FilterByName), interfaceType).Length > 0;
        }
        private static bool FilterByName(Type typeObj, object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }
      
    }
}
