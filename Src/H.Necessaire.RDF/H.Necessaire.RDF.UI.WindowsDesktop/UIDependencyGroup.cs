namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    internal class UIDependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry
                .Register<UINavigation.DependencyGroup>(() => new UINavigation.DependencyGroup())
                ;
        }
    }
}
