using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents
{
    public interface ImAUIComponent<TState> where TState : ImAUIComponentState
    {
        bool IsBusy { get; }
        TState CurrentState { get; }
        Task Initialize();
        Task Destroy();
        Task RunAtStartup();

        Task ApplyState(TState state);
    }
}
