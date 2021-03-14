using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        // Burasıda class'ın metodun Attribute'larını oku anlamına gelir
        // Listeye ekler
        // Önceliğe göre sıralar
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.AddRange(new ExceptionLogAspect(typeof(fileLogger)));  -->  Otomatik olarak sistemdeki bütün metodları log'a dahil et

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}
