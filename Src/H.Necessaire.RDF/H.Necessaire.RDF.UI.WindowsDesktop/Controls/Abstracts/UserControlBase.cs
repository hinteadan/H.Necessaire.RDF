using H.Necessaire.RDF.UI.Runtime;
using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UIComponents.Concrete;
using H.Necessaire.RDF.UI.Runtime.UINavigation;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.WindowsDesktop.Controls.Abstracts
{
    public abstract partial class UserControlBase<TState> : UserControl, ImAUIComponent<TState>, INotifyPropertyChanged, IAsyncDisposable where TState : ImAUIComponentState
    {
        #region Construct
        readonly UIComponentComposer<TState> composer;
        readonly ImAUINavigator uiNavigator;

        public event PropertyChangedEventHandler PropertyChanged;

        public UserControlBase(TState initialState)
        {
            composer = new UIComponentComposer<TState>();
            composer.ApplyState(initialState);
            uiNavigator = HNApp.Lication.Deps.Get<ImAUINavigator>();

            Loading += PageUserControlBase_Loading;
            Loaded += UserControlBase_Loaded;
        }

        private void PageUserControlBase_Loading(Microsoft.UI.Xaml.FrameworkElement sender, object args)
        {
            Initialize().Wait(TimeSpan.FromSeconds(3));
        }

        private async void UserControlBase_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            using (BusyFlag())
            {
                await RunAtStartup();
            }
        }

        public async ValueTask DisposeAsync()
        {
            Loaded -= UserControlBase_Loaded;
            Loading -= PageUserControlBase_Loading;

            await Destroy();
        }
        #endregion

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

        public virtual async Task ApplyState(TState state)
        {
            await composer.ApplyState(state);
            NotifyStateChanged();
        }

        protected ImAUINavigator Navi => uiNavigator;

        protected void NotifyStateChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
