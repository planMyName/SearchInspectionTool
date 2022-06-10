using System;
using System.Net.Http;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Sit.App
{
    public static class Bootstrapper
    {
        private static ILifetimeScope? _lifetimeScope;
        private static ServiceProvider _serviceProvider;

        public static void Start()
        {
            if (_lifetimeScope != null) return;
            var builder = new ContainerBuilder();
            var assemblies = new[] {
                Assembly.LoadFrom("Sit.Core.dll"),
                Assembly.LoadFrom("Sit.Data.dll")};

            _serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            builder.Register(c => _serviceProvider.GetService<IHttpClientFactory>()).As<IHttpClientFactory>();

            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }

            _lifetimeScope = builder.Build();
        }

        public static void Stop()
        {
            _serviceProvider?.Dispose();
            _lifetimeScope?.Dispose();
        }

        public static T Resolve<T>()
        {
            if (_lifetimeScope == null) throw new Exception("Bootstrapper hasn't been started!");

            return _lifetimeScope.Resolve<T>(new Parameter[0]);
        }

        public static T Resolve<T>(Parameter[] parameters)
        {
            if (_lifetimeScope == null) throw new Exception("Bootstrapper hasn't been started!");

            return _lifetimeScope.Resolve<T>(parameters);
        }   
    }
}
