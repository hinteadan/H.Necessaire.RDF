using H.Necessaire.RDF.UI.Runtime;
using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UIComponents.Concrete;
using H.Necessaire.RDF.UI.Runtime.UINavigation;
using H.Necessaire.RDF.UI.WindowsDesktop.Controls.Abstracts;
using Microsoft.UI.Xaml.Controls;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts
{
    public abstract partial class PageUserControlBase<TState> : UserControlBase<TState>, ImAUIPage<TState>, INotifyPropertyChanged, IAsyncDisposable where TState : ImAUIComponentState
    {
        #region Construct
        readonly UIPageComposer<TState> pageComposer;

        public PageUserControlBase(TState initialState) : base(initialState)
        {
            pageComposer = new UIPageComposer<TState>(GetType());
            pageComposer.ApplyState(initialState);
        }
        #endregion

        public virtual string Title => pageComposer.Title;


        public virtual async Task Use(UINavigationParams navigationParams)
        {
            await pageComposer.Use(navigationParams);
        }
    }
}
