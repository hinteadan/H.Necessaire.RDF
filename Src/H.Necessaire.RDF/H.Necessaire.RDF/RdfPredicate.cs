using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public class RdfPredicate<TPayload> : RdfConcreteConceptBase<TPayload>
    {
        #region Construct
        public RdfPredicate(Func<Task<TPayload>> payloadAcquirer, ImAnRdfConcept meta) : base(payloadAcquirer, meta)
        {
        }

        public RdfPredicate(TPayload payload, ImAnRdfConcept meta) : base(payload, meta)
        {
        }
        #endregion

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Predicate;
    }
}
