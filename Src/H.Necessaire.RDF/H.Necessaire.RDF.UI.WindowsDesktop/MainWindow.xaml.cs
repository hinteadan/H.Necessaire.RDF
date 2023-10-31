using H.Necessaire.RDF.UI.Runtime;
using H.Necessaire.RDF.UI.WindowsDesktop.UINavigation;
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
        public MainWindow()
        {
            this.InitializeComponent();

            this.ExtendsContentIntoTitleBar = true;

            HNApp.Lication.Deps.Register<UINavigationRuntimeContext>(() => new UINavigationRuntimeContext(pageChrome));

            pageChrome.Body = new Pages.HomePage();
        }
    }
}
