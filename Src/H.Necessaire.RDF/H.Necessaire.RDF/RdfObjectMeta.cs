namespace H.Necessaire.RDF
{
    public class RdfObjectMeta : RdfConceptBase
    {
        public RdfObjectMeta() : base()
        {
        }

        public RdfObjectMeta(ImAnRdfConcept meta) : base(meta)
        {
        }

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Object;

        public static implicit operator RdfObjectMeta(string value) => new RdfObjectMeta().And(x => x.Value(value));
    }
}
