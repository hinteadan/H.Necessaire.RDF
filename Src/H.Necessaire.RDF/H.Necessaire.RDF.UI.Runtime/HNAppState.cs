namespace H.Necessaire.RDF.UI.Runtime
{
    public class HNAppState
    {
        private RdfGraph currentRdfGraph = null;

        public RdfGraph CurrentRdfGraph
        {
            get => currentRdfGraph;
            set => currentRdfGraph = value;
        }
    }
}
