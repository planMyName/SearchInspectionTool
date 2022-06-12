using Autofac;

namespace Sit.Data.DependencyInjection;

public class WebDataModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        builder.Register(c => c.Resolve<IHttpClientFactory>().CreateClient()).As<HttpClient>();
        builder.RegisterType<WebRepository>().As<IWebRepository>();
    }
}