using System.Windows;
using Sit.Core.Abstractions;

namespace Sit.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Bootstrapper.Start();

            WireUpMainWindow();
        }

        private void WireUpMainWindow()
        {
            var docInspectionService = Bootstrapper.Resolve<IDocumentInspectionService>();
            var window = new MainWindow(docInspectionService);
            window.Closed += (obj, evtArg) => HandleWindowClose();

            window.Show();
        }

        private void HandleWindowClose()
        {
            Bootstrapper.Stop();
        }
    }
}
