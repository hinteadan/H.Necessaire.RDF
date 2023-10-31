using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UINavigation.Abstracts;
using H.Necessaire.RDF.UI.WindowsDesktop.Chromes;
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
        ImAUIPageContainer pageContainer;
        public override void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            base.ReferDependencies(dependencyProvider);
            navigationRuntimeContext = dependencyProvider.Get<UINavigationRuntimeContext>();
            pageContainer = navigationRuntimeContext.PageContainer;
        }

        protected override async Task DisposePage(ImAUIPage page)
        {
            pageContainer.Body = null;

            if (page is IAsyncDisposable)
                await new Func<Task>(async () => await (page as IAsyncDisposable).DisposeAsync()).TryOrFailWithGrace(onFail: null);
            if (page is IDisposable)
                new Action(() => (page as IDisposable).Dispose()).TryOrFailWithGrace(onFail: null);
        }

        protected override Task PresentPage(ImAUIPage page)
        {
            pageContainer.Body = page;

            return Task.CompletedTask;
        }
    }
}
