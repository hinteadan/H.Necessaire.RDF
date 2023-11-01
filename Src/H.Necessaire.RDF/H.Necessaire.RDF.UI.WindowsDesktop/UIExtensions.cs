using Microsoft.UI.Xaml.Controls;
using System;

namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    static class UIExtensions
    {
        public static IDisposable DisabledScope(this Control button)
        {
            return
                new ScopedRunner(
                    onStart: () => button.IsEnabled = false,
                    onStop: () => button.IsEnabled = true
                );
        }
    }
}
