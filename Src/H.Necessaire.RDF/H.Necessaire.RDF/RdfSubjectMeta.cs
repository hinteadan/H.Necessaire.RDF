namespace H.Necessaire.RDF
{
    public class RdfSubjectMeta : RdfConceptBase
    {
        public RdfSubjectMeta() : base()
        {
        }

        public RdfSubjectMeta(ImAnRdfConcept meta) : base(meta)
        {
        }

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Subject;

        public static implicit operator RdfSubjectMeta(string value)
            => new RdfSubjectMeta()
            .And(x => x.Value(value))
            ;
    }
}
