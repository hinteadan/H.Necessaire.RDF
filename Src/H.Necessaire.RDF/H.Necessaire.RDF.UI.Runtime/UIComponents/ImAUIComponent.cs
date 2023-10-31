using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents
{
    public interface ImAUIComponent
    {
        event EventHandler OnIsBusyChanged;

        bool IsBusy { get; }
        RuntimeConfig Config { get; }
        BrandingStyle Branding { get; }
        T Get<T>();
        ImALogger GetLogger<T>();
        Task<Version> GetAppVersion();


        Task Initialize();
        Task Destroy();
        Task RunAtStartup();

        IDisposable BusyFlag();
    }

    public interface ImAUIComponent<TState> : ImAUIComponent where TState : ImAUIComponentState
    {
        TState CurrentState { get; }
        Task ApplyState(TState state);
    }
}
