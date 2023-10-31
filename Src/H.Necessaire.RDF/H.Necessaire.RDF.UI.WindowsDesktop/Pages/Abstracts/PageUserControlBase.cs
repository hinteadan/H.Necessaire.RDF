using H.Necessaire.RDF.UI.Runtime;
using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UIComponents.Concrete;
using H.Necessaire.RDF.UI.Runtime.UINavigation;
using H.Necessaire.RDF.UI.WindowsDesktop.UINavigation;
using Microsoft.UI.Xaml.Controls;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts
{
    public abstract partial class PageUserControlBase<TState> : UserControl, ImAUIPage<TState>, INotifyPropertyChanged where TState : ImAUIComponentState
    {
        readonly UIPageComposer<TState> composer;
        readonly ImAUINavigator uiNavigator;

        public event PropertyChangedEventHandler PropertyChanged;

        public PageUserControlBase(TState initialState)
        {
            composer = new UIPageComposer<TState>(GetType());
            composer.ApplyState(initialState);
            uiNavigator = HNApp.Lication.Deps.Get<ImAUINavigator>();
        }
        public virtual string Title => composer.Title;

        public bool IsBusy => composer.IsBusy;

        public RuntimeConfig Config => composer.Config;

        public BrandingStyle Branding => composer.Branding;

        public TState State => composer.State;

        public IDisposable BusyFlag() => composer.BusyFlag();
        public T Get<T>() => composer.Get<T>();

        public Task<Version> GetAppVersion() => composer.GetAppVersion();

        public ImALogger GetLogger<T>() => composer.GetLogger<T>();



        public virtual async Task Initialize()
        {
            await composer.Initialize();
        }

        public virtual async Task Destroy()
        {
            await composer.Destroy();
        }

        public virtual async Task OnBusyChanged()
        {
            await composer.OnBusyChanged();
        }

        public virtual async Task RunAtStartup()
        {
            await composer.RunAtStartup();
        }

        public virtual async Task Use(UINavigationParams navigationParams)
        {
            await composer.Use(navigationParams);
        }

        public async Task ApplyState(TState state)
        {
            await composer.ApplyState(state);
            NotifyStateChanged();
        }

        protected ImAUINavigator Navi => uiNavigator;

        private void NotifyStateChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
