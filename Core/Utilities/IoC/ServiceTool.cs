using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{

    //builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
    // builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
    // Yukarıdaki örnekteki gibi;
    // Autofac'de oluşturulan Injection'ları, oluşturabilmeyi sağlıyor. Interface servisteki karşılığını bu tool vasıtası ile alınabilir 
    public static class ServiceTool   
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
