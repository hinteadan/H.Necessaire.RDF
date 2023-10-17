namespace H.Necessaire.RDF
{
    public class RdfPredicateMeta : RdfConceptBase
    {
        public RdfPredicateMeta() : base()
        {
        }

        public RdfPredicateMeta(ImAnRdfConcept meta) : base(meta)
        {
        }

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Predicate;

        public static implicit operator RdfPredicateMeta(string value) => new RdfPredicateMeta().And(x => x.Value(value));
    }
}
