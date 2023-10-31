using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using H.Necessaire.RDF.UI.Runtime.UseCases;
using H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
            using ((sender as Button).DisabledScope())
            {
                State.DebugLabel = DateTime.UtcNow.ToString();
                await ApplyState(State);
                await DebugInternetCalls();
            }
        }

        private async Task DebugInternetCalls()
        {
            using (HttpClient http = BuildNewHttpClient())
            {
                string httpContent = await http.GetStringAsync("https://hintea.com");
            }
        }

        static HttpClient BuildNewHttpClient()
        {
            return
                new HttpClient
                (
                    handler: BuildNewSocketsHttpHandler(),
                    disposeHandler: true
                );
        }

        static SocketsHttpHandler BuildNewSocketsHttpHandler()
        {
            return
                new SocketsHttpHandler
                {
                    // The maximum idle time for a connection in the pool. When there is no request in
                    // the provided delay, the connection is released.
                    // Default value in .NET 6: 1 minute
                    PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1),

                    // This property defines maximal connection lifetime in the pool regardless
                    // of whether the connection is idle or active. The connection is reestablished
                    // periodically to reflect the DNS or other network changes.
                    // ⚠️ Default value in .NET 6: never
                    //    Set a timeout to reflect the DNS or other network changes
                    PooledConnectionLifetime = TimeSpan.FromHours(.5),
                };
        }
    }
}
