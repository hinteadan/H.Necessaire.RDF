namespace H.Necessaire.RDF.UI.Runtime.Managers
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry
                .Register<AppStateManager>(() => new AppStateManager())
                ;
        }
    }
}
