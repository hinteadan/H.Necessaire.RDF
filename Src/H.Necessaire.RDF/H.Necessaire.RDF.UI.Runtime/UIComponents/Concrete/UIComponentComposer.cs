using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents.Concrete
{
    public class UIComponentComposer : UIComponentBase
    {
    }

    public class UIComponentComposer<TState> : UIComponentBase<TState> where TState : ImAUIComponentState
    {
    }
}
