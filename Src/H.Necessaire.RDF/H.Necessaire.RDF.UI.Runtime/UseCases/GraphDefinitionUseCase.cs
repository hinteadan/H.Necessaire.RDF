using H.Necessaire.Runtime;
using System;
using System.Threading.Tasks;

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

        public async Task<RdfGraph> GetCurrentRdfGraph()
        {
            return
                await appStateManager.GetCurrentRdfGraph();
            ;
        }

        public async Task GenerateNewRdfGraphID()
        {
            await
                graphDefinitionManager.GenerateNewRdfGraphID(
                    await appStateManager.GetCurrentRdfGraph()
                );
        }

        public async Task UpdateRdfGraphNotes(Note[] notes)
        {
            await
                graphDefinitionManager.UpdateRdfGraphNotes(
                    await appStateManager.GetCurrentRdfGraph(),
                    notes
                );
        }
    }
}
