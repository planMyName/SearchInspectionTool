using System.Windows;
using Sit.App.Core.Services;

namespace Sit.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Bootstrapper.Start();

            WireUpMainWindow();
        }

        private void WireUpMainWindow()
        {
            var documentService = Bootstrapper.Resolve<IDocumentService>();
            var window = new MainWindow(documentService);
            window.Closed += (obj, evtArg) => HandleWindowClose();

            window.Show();
        }

        private void HandleWindowClose()
        {
            Bootstrapper.Stop();
        }
    }
}
