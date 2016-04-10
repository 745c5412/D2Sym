using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace D2Sym.D2O
{
    /// <summary>
    /// Credit to Bouh2 (www.github.com/Timorem)
    /// </summary>
    static class ReflectionExtensions 
    {
        #region Public methods
        public static T CreateDelegate<T>(this ConstructorInfo ctor)
        {
            var parameters = ctor.GetParameters().Select(param => Expression.Parameter(param.ParameterType)).ToList();

            var lamba = Expression.Lambda<T>(Expression.New(ctor, parameters), parameters);

            return lamba.Compile();
        }
        #endregion
    }
}
