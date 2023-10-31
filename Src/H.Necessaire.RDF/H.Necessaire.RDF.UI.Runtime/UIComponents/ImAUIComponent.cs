using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents
{
    public interface ImAUIComponent
    {
        bool IsBusy { get; }
        Task Initialize();
        Task Destroy();
        Task RunAtStartup();
    }

    public interface ImAUIComponent<TState> : ImAUIComponent where TState : ImAUIComponentState
    {
        TState CurrentState { get; }
        Task ApplyState(TState state);
    }
}
