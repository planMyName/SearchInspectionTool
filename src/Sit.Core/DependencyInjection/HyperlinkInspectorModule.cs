using Autofac;
using Sit.Core.Document;

namespace Sit.Core.DependencyInjection;

public class HyperlinkInspectorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DocumentInspectionService>().As<IDocumentInspectionService>();
        builder.RegisterType<DocumentTokenizer>().As<IDocumentTokenizer>();
    }
}