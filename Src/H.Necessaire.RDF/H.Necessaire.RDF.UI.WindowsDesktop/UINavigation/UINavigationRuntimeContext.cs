using H.Necessaire.RDF.UI.WindowsDesktop.Chromes;

namespace H.Necessaire.RDF.UI.WindowsDesktop.UINavigation
{
    internal class UINavigationRuntimeContext
    {
        public UINavigationRuntimeContext(ImAUIPageContainer pageContainer)
        {
            this.PageContainer = pageContainer;
        }

        public ImAUIPageContainer PageContainer { get; }
    }
}
