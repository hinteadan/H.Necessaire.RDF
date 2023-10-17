namespace H.Necessaire.RDF
{
    public class RdfTripleMeta : RdfConceptBase
    {
        #region Construct
        public RdfTripleMeta() : base()
        {
        }

        public RdfTripleMeta(ImAnRdfConcept meta) : base(meta)
        {
        }

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Triple;
        #endregion

        public RdfSubjectMeta Subject { get; set; }
        public RdfPredicateMeta Predicate { get; set; }
        public RdfObjectMeta Object { get; set; }
    }
}
