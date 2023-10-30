using H.Necessaire.RDF.UI.Runtime.UINavigation;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents
{
    public interface ImAUIComponentState
    {
        Task Initialize();

        Task Use(UINavigationParams uiNavigationParams);

        Task Destroy();
    }
}
