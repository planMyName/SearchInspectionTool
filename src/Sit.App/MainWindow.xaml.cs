using System.Windows;
using Sit.Core.Abstractions;

namespace Sit.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDocumentInspectionService _documentInspectionService;
        private const int MaximumResultCount = 100;

        public MainWindow(IDocumentInspectionService documentInspectionService)
        {
            _documentInspectionService = documentInspectionService;
            InitializeComponent();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var inspectionRequest =
                new InspectionRequestDetail(UrlTextbox.Text, InspectStringTextbox.Text, MaximumResultCount);

            var result = await _documentInspectionService.Inspect(inspectionRequest);

            if (result != null)
            {
                ResultTextBox.Text = "";
            }
        }
    }
}
