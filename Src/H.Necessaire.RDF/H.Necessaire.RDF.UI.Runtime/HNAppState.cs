namespace H.Necessaire.RDF.UI.Runtime
{
    internal class HNAppState
    {
        private RdfGraph currentRdfGraph = null;

        public RdfGraph CurrentRdfGraph
        {
            get => currentRdfGraph;
            set => currentRdfGraph = value;
        }
    }
}
