using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public class RdfPredicate<TBody> : RdfConcreteConceptBase<TBody>
    {
        #region Construct
        public RdfPredicate(Func<Task<TBody>> bodyAcquirer, ImAnRdfConcept meta) : base(bodyAcquirer, meta)
        {
        }

        public RdfPredicate(TBody body, ImAnRdfConcept meta) : base(body, meta)
        {
        }
        #endregion

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Predicate;

        public static implicit operator RdfPredicate<TBody>((Func<Task<TBody>> bodyAcquirer, ImAnRdfConcept meta) parts)
            => new RdfPredicate<TBody>(parts.Item1, parts.Item2);
        public static implicit operator RdfPredicate<TBody>((TBody, ImAnRdfConcept) parts)
            => new RdfPredicate<TBody>(parts.Item1, parts.Item2);
    }
}
