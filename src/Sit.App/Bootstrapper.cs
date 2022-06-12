using System;
using System.Net.Http;
using System.Reflection;
using Autofac;
using Autofac.Core;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Sit.App;

public static class Bootstrapper
{
    private static ILifetimeScope? _lifetimeScope;
    private static ServiceProvider _serviceProvider;

    public static void Start()
    {
        if (_lifetimeScope != null) return;
        var builder = new ContainerBuilder();

        RegisterServices(builder);
        RegisterDIAssemblies(builder);

        _lifetimeScope = builder.Build();
    }

    private static void RegisterDIAssemblies(ContainerBuilder builder)
    {
        var assemblies = GetDependencyInjectionAssemblies();

        foreach (var assembly in assemblies)
        {
            builder.RegisterAssemblyModules(assembly);
        }
    }

    private static void RegisterServices(ContainerBuilder builder)
    {
        var autoMapperAssemblies = GetAutoMapperAssemblies();

        _serviceProvider = new ServiceCollection().AddAutoMapper(autoMapperAssemblies).AddHttpClient()
            .BuildServiceProvider();
        builder.Register(c => _serviceProvider.GetService<IHttpClientFactory>()).As<IHttpClientFactory>();
        builder.Register(c => _serviceProvider.GetService<IMapper>()).As<IMapper>();
    }

    private static Assembly[] GetDependencyInjectionAssemblies()
    {
        return new[]
        {
            //ToDo: Enhancement > can load from config file.
            Assembly.LoadFrom("Sit.App.Core.dll"),
            Assembly.LoadFrom("Sit.Core.Abstractions.dll"),
            Assembly.LoadFrom("Sit.Core.dll"),
            Assembly.LoadFrom("Sit.Data.dll")
        };
    }

    private static Assembly[] GetAutoMapperAssemblies()
    {
        return new[]
        {
            //ToDo: Enhancement > can load from config file.
            Assembly.LoadFrom("Sit.App.Core.dll"),
            Assembly.LoadFrom("Sit.Core.Abstractions.dll"),
            Assembly.LoadFrom("Sit.Data.Abstractions.dll"),
        };
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