using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.Managers
{
    internal class AppStateManager : ImADependency
    {
        #region Construct
        HNAppState appState;
        public void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            appState = dependencyProvider.Get<HNAppState>();
        }
        #endregion

        public Task SetCurrentRdfGraphTo(RdfGraph rdfGraph)
        {
            appState.CurrentRdfGraph = rdfGraph;
            return true.AsTask();
        }

        public Task<RdfGraph> GetCurrentRdfGraph()
        {
            return
                appState
                .CurrentRdfGraph
                .AsTask()
                ;
        }
    }
}
