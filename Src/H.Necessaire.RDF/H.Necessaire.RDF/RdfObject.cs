using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public class RdfObject<TPayload> : RdfConcreteConceptBase<TPayload>
    {
        #region Construct
        public RdfObject(Func<Task<TPayload>> payloadAcquirer, ImAnRdfConcept meta) : base(payloadAcquirer, meta)
        {
        }

        public RdfObject(TPayload payload, ImAnRdfConcept meta) : base(payload, meta)
        {
        }
        #endregion

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Object;
    }
}
