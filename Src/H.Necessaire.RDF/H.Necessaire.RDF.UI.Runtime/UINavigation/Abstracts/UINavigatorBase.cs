using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.WellKnown;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UINavigation.Abstracts
{
    public abstract class UINavigatorBase : ImAUINavigator, ImADependency
    {
        #region Construct
        readonly IDictionary<string, Func<Task<ImAUIPage>>> routes;
        protected readonly Stack<(string path, ImAUIPage page)> navigationStack = new Stack<(string path, ImAUIPage page)>();
        protected UINavigatorBase(IDictionary<string, Func<Task<ImAUIPage>>> routes)
        {
            this.routes = routes ?? new Dictionary<string, Func<Task<ImAUIPage>>>();
        }

        ImALogger logger;
        public virtual void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            logger = dependencyProvider.GetLogger<UINavigatorBase>();
        }

        protected abstract Task PresentPage(ImAUIPage page);
        protected abstract Task DisposePage(ImAUIPage page);
        #endregion



        public async Task Go(string path, UINavigationParams navigationParams = null)
        {
            if (!routes.ContainsKey(path))
            {
                await logger.LogError($"Error occured while trying to navigate to {path}. Message: There's no page registered with path {path}", new { path, navigationParams });
                return;
            }

            ImAUIPage page = await routes[path].Invoke();
            await page.Use(navigationParams);

            navigationStack.Push((path, page));

            await PresentPage(page);
        }

        public async Task GoBack()
        {
            if (navigationStack.Count <= 1)
                return;

            (string path, ImAUIPage page) itemToRemove = navigationStack.Pop();
            (string path, ImAUIPage page) itemToShow = navigationStack.Peek();

            await DisposePage(itemToRemove.page);
            await PresentPage(itemToShow.page);
        }

        public async Task GoHome(UINavigationParams navigationParams = null) => await Go(WellKnownPath.Home, navigationParams);

        public async Task ClearHistory()
        {
            if (navigationStack.Count <= 1)
                return;

            (string path, ImAUIPage page) itemToKeep = navigationStack.Pop();

            while (navigationStack.Count > 0)
            {
                (string path, ImAUIPage page) itemToDispose = navigationStack.Pop();
                await DisposePage(itemToDispose.page);
            }

            navigationStack.Push(itemToKeep);
        }
    }
}
