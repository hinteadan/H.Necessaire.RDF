using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public class RdfSubject<TPayload> : RdfConceptBase<TPayload>
    {
        #region Construct
        readonly RdfPayloadAcquirer<TPayload> payloadAcquirer;
        public RdfSubject(Func<Task<TPayload>> payloadAcquirer, ImAnRdfConcept meta) : base(meta)
        {
            this.payloadAcquirer = new RdfPayloadAcquirer<TPayload>(payloadAcquirer);
        }
        public RdfSubject(TPayload payload, ImAnRdfConcept meta) : base(meta)
        {
            this.payloadAcquirer = new RdfPayloadAcquirer<TPayload>(payload);
        }
        #endregion

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Subject;

        public override async Task<OperationResult<TPayload>> AcquirePayload() => await payloadAcquirer.AcquirePayload();
    }
}
