using H.Necessaire.RDF.UI.Runtime.UINavigation;
using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts
{
    public abstract class UIPageBase : UIComponentBase, ImAUIPage
    {
        readonly UIPageComposer composer;

        protected UIPageBase(Type ownerType)
        {
            composer = new UIPageComposer(ownerType);
        }

        public virtual string Title => composer.Title;

        public virtual Task Use(UINavigationParams navigationParams) => Task.CompletedTask;
    }

    public abstract class UIPageBase<TState> : UIComponentBase<TState>, ImAUIPage<TState> where TState : ImAUIComponentState
    {
        readonly UIPageComposer composer;

        protected UIPageBase(Type ownerType)
        {
            composer = new UIPageComposer(ownerType);
        }

        public virtual string Title => composer.Title;

        public virtual Task Use(UINavigationParams navigationParams) => Task.CompletedTask;
    }

    class UIPageComposer
    {
        static readonly RuntimeConfig runtimeConfig = HNApp.Lication.Deps.GetRuntimeConfig();
        protected readonly string titlePrefix = string.Empty;
        private readonly Type ownerType;
        public UIPageComposer(Type ownerType)
        {
            titlePrefix = runtimeConfig.Get("PageTitlePrefix")?.ToString() ?? string.Empty;
            this.ownerType = ownerType;
        }

        public string Title
        {
            get => !titlePrefix.IsEmpty() ? $"{titlePrefix} - {ownerType.Name.Replace("Page", string.Empty)}" : ownerType.Name.Replace("Page", string.Empty);
        }
    }
}
