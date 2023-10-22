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

        public static implicit operator RdfTriple<TSubject, TPredicate, TObject>((RdfSubject<TSubject>, RdfPredicate<TPredicate>, RdfObject<TObject>) parts)
            => new RdfTriple<TSubject, TPredicate, TObject>
            {
                Subject = parts.Item1,
                Predicate = parts.Item2,
                Object = parts.Item3,
            };

        public override string ToString()
        {
            return $"{Subject?.Value().NullIfEmpty() ?? Subject?.ID ?? "[No Subject]"} " +
                $"{Predicate?.Value().NullIfEmpty() ?? Predicate?.ID ?? "[No Predicate]"} " +
                $"{Object?.Value().NullIfEmpty() ?? Object?.ID ?? "[No Object]"} ";
        }
    }
}
