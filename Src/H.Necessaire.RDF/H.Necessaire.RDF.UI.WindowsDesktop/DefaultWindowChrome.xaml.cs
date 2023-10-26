using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    public sealed partial class DefaultWindowChrome : UserControl
    {
        static readonly DependencyProperty bodyProperty =
            DependencyProperty.Register("Body", typeof(object), typeof(DefaultWindowChrome), new PropertyMetadata(null));

        public DefaultWindowChrome()
        {
            this.InitializeComponent();
        }


        public object Body
        {
            get { return (object)GetValue(bodyProperty); }
            set { SetValue(bodyProperty, value); }
        }
    }
}
