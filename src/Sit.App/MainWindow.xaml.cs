using System.Windows;
using Sit.App.Core.Models;
using Sit.App.Core.Services;


namespace Sit.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDocumentService _documentService;
        private const int MaximumResultCount = 100;


        public MainWindow(IDocumentService documentService)
        {
            _documentService = documentService;
            InitializeComponent();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var inspectionRequest =
                new InspectionRequest(UrlTextbox.Text, InspectStringTextbox.Text, MaximumResultCount);

            var result = await _documentService.InspectAsync(inspectionRequest);

            if (result != null)
            {
                ResultTextBox.Text = result.ResultCsv;
            }
        }
    }
}
