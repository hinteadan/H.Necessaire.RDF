namespace H.Necessaire.RDF
{
    public class RdfTriple<TSubject, TPredicate, TObject> : RdfConceptBase
    {
        #region Construct
        public RdfTriple() : base()
        {
        }

        public RdfTriple(ImAnRdfConcept meta) : base(meta)
        {
        }

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Triple;
        #endregion

        public RdfSubject<TSubject> Subject { get; set; }
        public RdfPredicate<TPredicate> Predicate { get; set; }
        public RdfObject<TObject> Object { get; set; }
    }
}
