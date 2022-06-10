using Autofac;
using Sit.Core.Abstractions;

namespace Sit.Core.Installers
{
    public class HyperlinkInspectorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DocumentInspectionService>().As<IDocumentInspectionService>();
        }
    }
}
