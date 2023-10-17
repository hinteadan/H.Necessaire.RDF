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
    }
}
