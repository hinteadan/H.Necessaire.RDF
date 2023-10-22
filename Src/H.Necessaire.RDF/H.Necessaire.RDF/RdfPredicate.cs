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
    }
}
