using Autofac;
using Sit.Data.Abstractions;

namespace Sit.Data.Installers
{
    public class WebDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WebRepository>().As<IWebRepository>();
            builder.Register(c => c.Resolve<IHttpClientFactory>().CreateClient()).As<HttpClient>();
        }
    }
}
