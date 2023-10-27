using H.Necessaire.Runtime;
using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.UseCases
{
    public class HomePageUseCase : UseCaseBase
    {
        Managers.AppStateManager appStateManager;

        public override void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            base.ReferDependencies(dependencyProvider);
            appStateManager = dependencyProvider.Get<Managers.AppStateManager>();
        }

        public async Task CreateNewRdfGraph()
        {
            RdfGraph newGraph = new RdfGraph();
            await appStateManager.SetCurrentRdfGraphTo(newGraph);
        }
    }
}
