using H.Necessaire.RDF.UI.Runtime;
using Microsoft.UI.Xaml;
using System;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            HNApp.Lication.Deps.Register<UIDependencyGroup>(() => new UIDependencyGroup());
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            mainWindowManager = WindowManager.Get(m_window).And(x =>
            {
                x.PersistenceId = Guid.NewGuid().ToString();
                x.MinWidth = HNApp.Lication.Branding.SizingUnitInPixels * 64;
                x.MinHeight = HNApp.Lication.Branding.SizingUnitInPixels * 48;
            });
            m_window.Activate();
        }

        private Window m_window;
        private WindowManager mainWindowManager;
    }
}
