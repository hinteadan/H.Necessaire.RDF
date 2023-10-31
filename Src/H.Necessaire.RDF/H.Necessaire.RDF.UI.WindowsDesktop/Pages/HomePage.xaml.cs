using H.Necessaire.RDF.UI.Runtime;
using H.Necessaire.RDF.UI.Runtime.UseCases;
using H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages
{
    public sealed partial class HomePage : PageUserControlBase
    {
        HomePageUseCase useCase;
        public HomePage() : base()
        {
            this.InitializeComponent();
            useCase = HNApp.Lication.Deps.Get<HomePageUseCase>();
        }

        private async void CreateNewRdfGraph_Click(object sender, RoutedEventArgs e)
        {
            using (new ScopedRunner(
                () => ((Button)sender).IsEnabled = false,
                () => ((Button)sender).IsEnabled = true)
            )
            {
                await useCase.CreateNewRdfGraph();
            }
        }
    }
}
