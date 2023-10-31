using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts
{
    public abstract class UIComponentBase : UserControl ImAUIComponent
    {
        private static readonly RuntimeConfig runtimeConfig = HNApp.Lication.Deps.GetRuntimeConfig();
        private static readonly BrandingStyle brandingStyle = HNApp.Lication.Branding;

        private bool isBusy = false;
        protected event EventHandler OnIsBusyChanged;

        public bool IsBusy
        {
            get => isBusy;
            private set => (isBusy = value).And(_ => RaiseOnIsBusyChanged());
        }

        public virtual Task Destroy() => Task.CompletedTask;

        public virtual Task Initialize() => Task.CompletedTask;

        public virtual Task RunAtStartup() => Task.CompletedTask;

        protected RuntimeConfig Config => runtimeConfig;
        protected BrandingStyle Branding => brandingStyle;
        protected T Get<T>() => HNApp.Lication.Deps.Get<T>();
        protected ImALogger GetLogger<T>() => HNApp.Lication.Deps.GetLogger<T>("H.Necessaire.RDF.UI");
        protected async Task<Version> GetAppVersion() => (await HNApp.Lication.Deps.Get<ImAVersionProvider>()?.GetCurrentVersion());

        protected IDisposable BusyFlag()
        {
            return
                new ScopedRunner(
                    onStart: () => IsBusy = true,
                    onStop: () => IsBusy = false
                );
        }

        private void RaiseOnIsBusyChanged()
        {
            if (OnIsBusyChanged == null)
                return;

            OnIsBusyChanged.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract class UIComponentBase<TState> : UIComponentBase, ImAUIComponent<TState> where TState : ImAUIComponentState
    {
        public TState CurrentState { get; private set; }

        public virtual Task ApplyState(TState state)
        {
            CurrentState = state;
            return Task.CompletedTask;
        }
    }
}
