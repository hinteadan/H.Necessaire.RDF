using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UINavigation;
using H.Necessaire.RDF.UI.Runtime.WellKnown;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.WindowsDesktop.UINavigation
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry
                .Register<ImAUINavigator>(() => new UINavigator(new Dictionary<string, Func<Task<ImAUIPage>>>{
                    { WellKnownPath.Home, () => new Pages.HomePage().AsTask<ImAUIPage>() },
                }))
                ;
        }
    }
}
