using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts;

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
        public RdfGraphDefinitionPage()
        {
            this.InitializeComponent();
        }

        public override string Title => "RDF Graph Definition";
    }
}
