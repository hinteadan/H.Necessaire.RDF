using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using H.Necessaire.RDF.UI.Runtime.UseCases;
using H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages
{
    public abstract class HomePageBase : PageUserControlBase<HomePageBase.PageState>
    {
        public HomePageBase() : base(new PageState { }) { }
        public class PageState : UIComponentStateBase
        {
            public string DebugLabel { get; set; } = DateTime.UtcNow.ToString();
        }
    }

    public sealed partial class HomePage : HomePageBase
    {
        HomePageUseCase useCase;
        public HomePage() : base()
        {
            this.InitializeComponent();
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
                await Navi.Go(NavPath.RdfGraphDefinition);
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
                await ApplyState(State);
            }
        }
    }
}
