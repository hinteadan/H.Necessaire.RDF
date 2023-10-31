using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UINavigation.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.WindowsDesktop.UINavigation
{
    internal class UINavigator : UINavigatorBase
    {
        public UINavigator(IDictionary<string, Func<Task<ImAUIPage>>> routes) : base(routes)
        {
        }

        UINavigationRuntimeContext navigationRuntimeContext;
        public override void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            base.ReferDependencies(dependencyProvider);
            navigationRuntimeContext = dependencyProvider.Get<UINavigationRuntimeContext>();
        }

        protected override Task DisposePage(ImAUIPage page)
        {
            throw new NotImplementedException();
        }

        protected override Task PresentPage(ImAUIPage page)
        {
            throw new NotImplementedException();
        }
    }
}
