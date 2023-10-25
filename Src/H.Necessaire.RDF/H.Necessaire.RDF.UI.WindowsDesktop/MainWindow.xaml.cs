using H.Necessaire.RDF.UI.Runtime;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        readonly ImALogger logger;
        public MainWindow()
        {
            this.InitializeComponent();

            this.logger = HNApp.Licat.Ion.GetLogger<MainWindow>(application: "H.Necessaire.RDF.UI.WindowsDesktop");
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";

            await logger.LogWarn("myButton_Click Clicked");
        }
    }
}
