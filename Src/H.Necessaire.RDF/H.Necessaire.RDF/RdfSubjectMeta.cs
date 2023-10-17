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
    }
}
