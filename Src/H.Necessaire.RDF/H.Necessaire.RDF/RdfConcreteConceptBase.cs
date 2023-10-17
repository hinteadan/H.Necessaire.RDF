using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public abstract class RdfConcreteConceptBase<TPayload> : RdfConceptBase<TPayload>
    {
        #region Construct
        readonly RdfPayloadAcquirer<TPayload> payloadAcquirer;
        protected RdfConcreteConceptBase(Func<Task<TPayload>> payloadAcquirer, ImAnRdfConcept meta) : base(meta)
        {
            this.payloadAcquirer = new RdfPayloadAcquirer<TPayload>(payloadAcquirer);
        }
        protected RdfConcreteConceptBase(TPayload payload, ImAnRdfConcept meta) : base(meta)
        {
            this.payloadAcquirer = new RdfPayloadAcquirer<TPayload>(payload);
        }
        #endregion

        public override async Task<OperationResult<TPayload>> AcquirePayload() => await payloadAcquirer.AcquirePayload();
    }
}
