using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DynamicLoaderService
{
    public class DynamicLoaderServiceImpl
    {
        public void LoadServices(IServiceCollection services, string path)
        {
            var servicePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            var files = Directory.GetFiles(servicePath, "*.dll");
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                foreach (var type in assembly.GetTypes())
                {
                    var loaderAttribute = type.GetCustomAttribute<LoaderAttribute>();
                    if (loaderAttribute != null)
                    {
                        switch (loaderAttribute.Policy)
                        {
                            case Policy.Transient:
                                services.AddTransient(loaderAttribute.InterfaceType, loaderAttribute.ImplementationType);
                                break;
                            case Policy.Scoped:
                                services.AddScoped(loaderAttribute.InterfaceType, loaderAttribute.ImplementationType);
                                break;
                            case Policy.Singelton:
                                services.AddSingleton(loaderAttribute.InterfaceType, loaderAttribute.ImplementationType);
                                break;
                        }
                    }
                }
            }
        }
    }
}
