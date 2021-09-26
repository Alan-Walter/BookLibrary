using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BookLibrary.Core.Helpers
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Получить список классов-наследников, не являющихся абстрактными классами или интерфейсами
        /// </summary>
        /// <param name="type">Тип, наследников которого необходимо получить</param>
        /// <returns>Список наследников типа</returns>
        public static IEnumerable<Type> GetImplimentationTypes(Type type)
        {
            return Assembly.GetAssembly(type)
                .GetTypes()
                .Where(i => !i.IsAbstract && 
                    !i.IsInterface && 
                    i != type && 
                    !type.IsGenericType && type.IsAssignableFrom(i) || 
                    (i.BaseType.IsGenericType && i.BaseType.GetGenericTypeDefinition() == type)
                    )
                .ToList();
        }
    }
}
