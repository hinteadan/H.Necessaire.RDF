using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UINavigation
{
    public interface ImAUINavigator
    {
        Task Go(string path, UINavigationParams navigationParams = null);
        Task GoHome(UINavigationParams navigationParams = null);
        Task GoBack();
        Task ClearHistory();
    }
}
