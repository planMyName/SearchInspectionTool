using System;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace Sit.App
{
    public static class Bootstrapper
    {
        private static ILifetimeScope _lifetimeScope;


        public static void Start()
        {
            if (_lifetimeScope != null) return;
            var builder = new ContainerBuilder();
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }

            _lifetimeScope = builder.Build();
        }

        public static void Stop()
        {
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
