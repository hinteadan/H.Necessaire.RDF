using H.Necessaire.RDF.UI.Runtime.UINavigation;

namespace H.Necessaire.RDF.UI.WindowsDesktop.UINavigation
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry
                .Register<ImAUINavigator>(() => new UINavigator(null))
                ;
        }
    }
}
