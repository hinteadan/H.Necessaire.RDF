using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts
{
    public abstract class UIComponentBase : ImAUIComponent
    {
        private static readonly RuntimeConfig runtimeConfig = HNApp.Lication.Deps.GetRuntimeConfig();
        private static readonly BrandingStyle brandingStyle = HNApp.Lication.Branding;

        private bool isBusy = false;

        public bool IsBusy
        {
            get => isBusy;
            private set => (isBusy = value).And(_ => OnBusyChanged().Wait(TimeSpan.FromSeconds(5)));
        }

        public virtual Task Destroy() => Task.CompletedTask;

        public virtual Task Initialize() => Task.CompletedTask;

        public virtual Task RunAtStartup() => Task.CompletedTask;

        public virtual Task OnBusyChanged() => Task.CompletedTask;

        public RuntimeConfig Config => runtimeConfig;
        public BrandingStyle Branding => brandingStyle;
        public T Get<T>() => HNApp.Lication.Deps.Get<T>();
        public ImALogger GetLogger<T>() => HNApp.Lication.Deps.GetLogger<T>("H.Necessaire.RDF.UI");
        public async Task<Version> GetAppVersion() => (await HNApp.Lication.Deps.Get<ImAVersionProvider>()?.GetCurrentVersion());

        public IDisposable BusyFlag()
        {
            return
                new ScopedRunner(
                    onStart: () => IsBusy = true,
                    onStop: () => IsBusy = false
                );
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
