using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using H.Necessaire.RDF.UI.Runtime.UseCases;
using H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages
{
    public abstract class RdfGraphDefinitionPageBase : PageUserControlBase<RdfGraphDefinitionPageBase.PageState>
    {
        public RdfGraphDefinitionPageBase() : base(new PageState { }) { }
        public class PageState : UIComponentStateBase
        {
            public RdfGraph RdfGraph { get; set; }
        }
    }
    public sealed partial class RdfGraphDefinitionPage : RdfGraphDefinitionPageBase
    {
        GraphDefinitionUseCase useCase;
        public RdfGraphDefinitionPage()
        {
            this.InitializeComponent();
            useCase = Get<GraphDefinitionUseCase>();
        }

        public override string Title => "RDF Graph Definition";

        private async void Back_Click(object sender, RoutedEventArgs e)
        {
            using (new ScopedRunner(
                () => ((Button)sender).IsEnabled = false,
                () => ((Button)sender).IsEnabled = true)
            )
            {
                await Navi.GoBack();
            }
        }
    }
}
