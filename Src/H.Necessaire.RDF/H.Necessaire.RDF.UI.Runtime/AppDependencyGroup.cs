namespace H.Necessaire.RDF.UI.Runtime
{
    internal class AppDependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry
                .Register<Managers.DependencyGroup>(() => new Managers.DependencyGroup())
                .Register<UseCases.DependencyGroup>(() => new UseCases.DependencyGroup())
                ;
        }
    }
}
