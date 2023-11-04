using H.Necessaire.RDF.UI.WindowsDesktop.Chromes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Elements
{
    public sealed partial class Section : UserControl
    {
        static readonly DependencyProperty title =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(Section), new PropertyMetadata(null));
        static readonly DependencyProperty titleVisibility =
            DependencyProperty.Register(nameof(TitleVisibility), typeof(Visibility), typeof(Section), new PropertyMetadata(null));
        static readonly DependencyProperty body =
            DependencyProperty.Register(nameof(Body), typeof(object), typeof(Section), new PropertyMetadata(null));

        public Section()
        {
            this.InitializeComponent();
        }

        public string Title {
            get => GetValue(title) as string;
            set { 
                SetValue(title, value);
                TitleVisibility = value.IsEmpty() ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        public Visibility TitleVisibility { get => (Visibility)GetValue(titleVisibility); set => SetValue(titleVisibility, value); }
        public string Description { get; set; }

        public object Body
        {
            get => GetValue(body);
            set => SetValue(body, value);
        }
    }
}
