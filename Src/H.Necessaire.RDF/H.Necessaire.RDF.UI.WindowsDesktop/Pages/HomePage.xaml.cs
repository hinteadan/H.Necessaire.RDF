using H.Necessaire.RDF.UI.Runtime;
using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using H.Necessaire.RDF.UI.Runtime.UINavigation;
using H.Necessaire.RDF.UI.Runtime.UseCases;
using H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages
{
    public sealed partial class HomePage : PageUserControlBase
    {
        public class PageState : UIComponentStateBase
        {
            public string DebugLabel { get; set; } = DateTime.UtcNow.ToString();
        }

        readonly PageStateController<PageState> stateController;
        public PageState State => stateController.State;
        public PageStateController<PageState> StateController => stateController;
        HomePageUseCase useCase;
        public HomePage() : base()
        {
            this.InitializeComponent();
            stateController = new PageStateController<PageState>(new PageState(), RaisePropertyChanged);
            useCase = Get<HomePageUseCase>();
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

        private async void Debug_Click(object sender, RoutedEventArgs e)
        {
            using (new ScopedRunner(
                () => ((Button)sender).IsEnabled = false,
                () => ((Button)sender).IsEnabled = true)
            )
            {
                State.DebugLabel = DateTime.UtcNow.ToString();
                await stateController.ApplyState(State);
            }
        }
    }
}
