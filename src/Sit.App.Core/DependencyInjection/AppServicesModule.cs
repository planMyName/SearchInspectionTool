using Autofac;
using Sit.App.Core.Services;

namespace Sit.App.Core.DependencyInjection
{
    public class AppServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DocumentService>().As<IDocumentService>();
        }

    }
}
