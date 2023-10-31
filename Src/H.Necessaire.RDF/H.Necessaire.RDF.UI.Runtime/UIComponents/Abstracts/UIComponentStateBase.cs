using H.Necessaire.RDF.UI.Runtime.UINavigation;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts
{
    public abstract class UIComponentStateBase : ImAUIComponentState
    {
        public Task Destroy() => Task.CompletedTask;

        public Task Initialize() => Task.CompletedTask;

        public Task Use(UINavigationParams uiNavigationParams) => Task.CompletedTask;
    }
}
