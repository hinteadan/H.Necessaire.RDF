using H.Necessaire.RDF.UI.Runtime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Elements
{
    public sealed partial class Section : UserControl
    {
        public Section()
        {
            this.InitializeComponent();
        }

        public string Title { get; set; }
        public Visibility TitleVisibility => Title.IsEmpty() ? Visibility.Collapsed : Visibility.Visible;
        public string Description { get; set; }
        public UIElement Body { get; set; }

        public GridLength TitleRowHeight => TitleVisibility == Visibility.Collapsed ? new GridLength(0, GridUnitType.Pixel) : new GridLength(HNApp.Lication.Branding.SizingUnitInPixels * 4, GridUnitType.Pixel);
    }
}
