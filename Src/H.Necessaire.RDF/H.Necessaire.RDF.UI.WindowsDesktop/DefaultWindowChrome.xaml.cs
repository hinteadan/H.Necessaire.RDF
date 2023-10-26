using H.Necessaire.RDF.UI.Runtime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    public sealed partial class DefaultWindowChrome : UserControl
    {
        static readonly DependencyProperty bodyProperty =
            DependencyProperty.Register("Body", typeof(object), typeof(DefaultWindowChrome), new PropertyMetadata(null));
        static readonly string copyright = HNApp.Lication.Deps.GetRuntimeConfig().Get("App").Get("Copyright").ToString().Replace("{year}", DateTime.Now.ToString("yyyy")).Replace("{version}", "v0.0.0-dev");

        public DefaultWindowChrome()
        {
            this.InitializeComponent();
        }


        public object Body
        {
            get => GetValue(bodyProperty);
            set => SetValue(bodyProperty, value);
        }

        public string Copyright => copyright;
    }
}
