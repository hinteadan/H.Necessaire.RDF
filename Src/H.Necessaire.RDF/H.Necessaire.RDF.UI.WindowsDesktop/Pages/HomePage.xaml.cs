using H.Necessaire.RDF.UI.Runtime;
using H.Necessaire.RDF.UI.Runtime.UseCases;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages
{
    public sealed partial class HomePage : UserControl
    {
        HomePageUseCase useCase;
        public HomePage()
        {
            this.InitializeComponent();
            useCase = HNApp.Lication.Deps.Get<HomePageUseCase>();
        }

        private async void CreateNewRdfGraph_Click(object sender, RoutedEventArgs e)
        {
            using (new ScopedRunner(
                () => ((Button)sender).IsEnabled = false,
                () => ((Button)sender).IsEnabled = true)
            )
            {
                await useCase.CreateNewRdfGraph();
            }
        }
    }
}
