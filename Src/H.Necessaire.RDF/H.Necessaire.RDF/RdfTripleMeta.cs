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

        public override string ToString()
        {
            return $"{Subject?.Value().NullIfEmpty() ?? Subject?.ID ?? "[No Subject]"} " +
                $"{Predicate?.Value().NullIfEmpty() ?? Predicate?.ID ?? "[No Predicate]"} " +
                $"{Object?.Value().NullIfEmpty() ?? Object?.ID ?? "[No Object]"}";
        }
    }
}
