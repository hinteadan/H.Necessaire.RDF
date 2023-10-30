namespace H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts
{
    public abstract class UIPageBase<TState> : UIComponentBase<TState>, ImAUIPage<TState> where TState : ImAUIComponentState
    {
        protected readonly string titlePrefix = string.Empty;

        protected UIPageBase()
        {
            titlePrefix = Config.Get("PageTitlePrefix")?.ToString() ?? string.Empty;
        }

        public virtual string Title
        {
            get => !titlePrefix.IsEmpty() ? $"{titlePrefix} - {this.GetType().Name.Replace("Page", string.Empty)}" : this.GetType().Name.Replace("Page", string.Empty);
        }
    }
}
