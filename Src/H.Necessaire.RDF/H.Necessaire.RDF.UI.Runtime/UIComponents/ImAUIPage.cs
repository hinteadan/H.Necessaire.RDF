using H.Necessaire.RDF.UI.Runtime.UINavigation;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents
{
    public interface ImAUIPage : ImAUIComponent
    {
        string Title { get; }
        Task Use(UINavigationParams navigationParams);
    }

    public interface ImAUIPage<TState> : ImAUIPage, ImAUIComponent<TState> where TState : ImAUIComponentState
    {

    }
}
