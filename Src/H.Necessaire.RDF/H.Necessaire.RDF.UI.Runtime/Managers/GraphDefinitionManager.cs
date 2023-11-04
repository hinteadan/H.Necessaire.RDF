using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.Runtime.Managers
{
    public class GraphDefinitionManager : ImADependency
    {
        #region Construct
        HNAppState appState;
        public void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            appState = dependencyProvider.Get<HNAppState>();
        }
        #endregion

        public Task GenerateNewRdfGraphID(RdfGraph rdfGraph)
        {
            if (rdfGraph is null)
                return Task.CompletedTask;

            rdfGraph.ID = Guid.NewGuid();

            return Task.CompletedTask;
        }

        public Task UpdateRdfGraphNotes(RdfGraph rdfGraph, Note[] notes)
        {
            if (rdfGraph is null)
                return Task.CompletedTask;

            rdfGraph.Notes = notes;

            return Task.CompletedTask;
        }
    }
}
