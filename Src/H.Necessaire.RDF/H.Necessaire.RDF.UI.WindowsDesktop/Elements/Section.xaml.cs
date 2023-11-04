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
        public Visibility TitleVisibility { get; set; }
        public string Description { get; set; }
        public UIElement Body { get; set; }
    }
}
