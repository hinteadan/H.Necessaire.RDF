namespace H.Necessaire.RDF.UI.Runtime.UseCases
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry
                .RegisterAlwaysNew<HomePageUseCase>(() => new HomePageUseCase())
                .RegisterAlwaysNew<GraphDefinitionUseCase>(() => new GraphDefinitionUseCase())
                ;
        }
    }
}
