using H.Necessaire.Runtime;

namespace H.Necessaire.RDF.UI.Runtime.UseCases
{
    public class GraphDefinitionUseCase : UseCaseBase
    {
        Managers.AppStateManager appStateManager;
        Managers.GraphDefinitionManager graphDefinitionManager;

        public override void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            base.ReferDependencies(dependencyProvider);
            appStateManager = dependencyProvider.Get<Managers.AppStateManager>();
            graphDefinitionManager = dependencyProvider.Get<Managers.GraphDefinitionManager>();
        }
    }
}
