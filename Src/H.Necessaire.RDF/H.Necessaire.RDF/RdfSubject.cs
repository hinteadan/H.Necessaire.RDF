using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public class RdfSubject<TPayload> : RdfConcreteConceptBase<TPayload>
    {
        #region Construct
        public RdfSubject(Func<Task<TPayload>> payloadAcquirer, ImAnRdfConcept meta) : base(payloadAcquirer, meta)
        {
        }

        public RdfSubject(TPayload payload, ImAnRdfConcept meta) : base(payload, meta)
        {
        }
        #endregion

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Subject;
    }
}
