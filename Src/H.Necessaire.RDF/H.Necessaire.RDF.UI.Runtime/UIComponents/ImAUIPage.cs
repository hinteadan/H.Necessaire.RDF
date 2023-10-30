namespace H.Necessaire.RDF.UI.Runtime.UIComponents
{
    public interface ImAUIPage<TState> : ImAUIComponent<TState> where TState : ImAUIComponentState
    {
        string Title { get; }
    }
}
