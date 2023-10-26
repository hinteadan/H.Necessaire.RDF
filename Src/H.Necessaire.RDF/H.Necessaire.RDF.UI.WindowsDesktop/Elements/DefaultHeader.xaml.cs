using H.Necessaire.RDF.UI.Runtime;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Elements
{
    public sealed partial class DefaultHeader : UserControl
    {
        static readonly string appDisplayName = HNApp.Lication.Deps.GetRuntimeConfig().Get("App").Get("DisplayName").ToString();
        public DefaultHeader()
        {
            this.InitializeComponent();
        }

        public string AppDisplayName => appDisplayName;
    }
}
