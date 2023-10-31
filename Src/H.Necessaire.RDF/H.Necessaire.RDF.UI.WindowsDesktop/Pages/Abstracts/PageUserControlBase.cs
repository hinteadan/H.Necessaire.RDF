using H.Necessaire.RDF.UI.Runtime;
using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UIComponents.Concrete;
using H.Necessaire.RDF.UI.Runtime.UINavigation;
using Microsoft.UI.Xaml.Controls;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts
{
    public abstract partial class PageUserControlBase : UserControl, ImAUIPage, INotifyPropertyChanged
    {
        readonly UIPageComposer composer;

        public event PropertyChangedEventHandler PropertyChanged;

        public PageUserControlBase()
        {
            composer = new UIPageComposer(GetType());
        }
        public string Title => composer.Title;

        public bool IsBusy => composer.IsBusy;

        public RuntimeConfig Config => composer.Config;

        public BrandingStyle Branding => composer.Branding;

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

        protected void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
    }
}
