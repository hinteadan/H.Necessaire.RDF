using System;
using System.Reflection;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public abstract class RdfConcreteConceptBase<TPayload> : RdfConceptBase<TPayload>
    {
        #region Construct
        static readonly PropertyInfo payloadIdProperty = ProcessPayloadIDProperty();
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

        public override async Task<OperationResult<TPayload>> AcquirePayload()
        {
            OperationResult<TPayload> result =
                await payloadAcquirer.AcquirePayload();

            if (result.IsSuccessful && result.Payload != null)
            {
                UpdatePayloadIdNote(result.Payload);
            }

            return result;
        }

        private void UpdatePayloadIdNote(TPayload payload)
        {
            OperationResult<string> payloadIdResult = GetPayloadID(payload);

            if (!payloadIdResult.IsSuccessful)
                return;

            PayloadID(payloadIdResult.Payload);
        }

        private static PropertyInfo ProcessPayloadIDProperty()
        {
            return
                typeof(TPayload)
                .GetProperty("ID", BindingFlags.Public | BindingFlags.Instance)
                ??
                typeof(TPayload)
                .GetProperty("Id", BindingFlags.Public | BindingFlags.Instance)
                ??
                typeof(TPayload)
                .GetProperty("id", BindingFlags.Public | BindingFlags.Instance)
                ;
        }

        private static OperationResult<string> GetPayloadID(TPayload payload)
        {
            if (payloadIdProperty is null)
                return OperationResult.Fail("Unknown ID property for payload").WithoutPayload<string>();

            OperationResult<string> result = OperationResult.Fail("Not yet started").WithoutPayload<string>();

            new Action(() =>
            {
                result = payloadIdProperty.GetValue(payload).ToString().ToWinResult();
            })
            .TryOrFailWithGrace(
                onFail: ex => result = OperationResult.Fail(ex, $"Error occured while trying to read ID of payload. Reason: {ex.Message}").WithoutPayload<string>()
            );

            return result;
        }
    }
}
