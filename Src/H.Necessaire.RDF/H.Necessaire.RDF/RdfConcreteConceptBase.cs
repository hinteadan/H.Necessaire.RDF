using System;
using System.Reflection;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public abstract class RdfConcreteConceptBase<TBody> : RdfConceptBase<TBody>
    {
        #region Construct
        static readonly PropertyInfo bodyIdProperty = ProcessBodyIDProperty();
        readonly RdfBodyAcquirer<TBody> bodyAcquirer;
        protected RdfConcreteConceptBase(Func<Task<TBody>> bodyAcquirer, ImAnRdfConcept meta) : base(meta)
        {
            this.bodyAcquirer = new RdfBodyAcquirer<TBody>(bodyAcquirer);
        }
        protected RdfConcreteConceptBase(TBody payload, ImAnRdfConcept meta) : base(meta)
        {
            this.bodyAcquirer = new RdfBodyAcquirer<TBody>(payload);
        }
        #endregion

        public override async Task<OperationResult<TBody>> AcquireBody()
        {
            OperationResult<TBody> result =
                await bodyAcquirer.AcquireBody();

            if (result.IsSuccessful && result.Payload != null)
            {
                UpdateBodyIdNote(result.Payload);
            }

            return result;
        }

        private void UpdateBodyIdNote(TBody body)
        {
            OperationResult<string> payloadIdResult = GetBodyID(body);

            if (!payloadIdResult.IsSuccessful)
                return;

            BodyID(payloadIdResult.Payload);
        }

        private static PropertyInfo ProcessBodyIDProperty()
        {
            return
                typeof(TBody)
                .GetProperty("ID", BindingFlags.Public | BindingFlags.Instance)
                ??
                typeof(TBody)
                .GetProperty("Id", BindingFlags.Public | BindingFlags.Instance)
                ??
                typeof(TBody)
                .GetProperty("id", BindingFlags.Public | BindingFlags.Instance)
                ;
        }

        private static OperationResult<string> GetBodyID(TBody body)
        {
            if (bodyIdProperty is null)
                return OperationResult.Fail("Unknown ID property for payload").WithoutPayload<string>();

            OperationResult<string> result = OperationResult.Fail("Not yet started").WithoutPayload<string>();

            new Action(() =>
            {
                result = bodyIdProperty.GetValue(body).ToString().ToWinResult();
            })
            .TryOrFailWithGrace(
                onFail: ex => result = OperationResult.Fail(ex, $"Error occured while trying to read ID of payload. Reason: {ex.Message}").WithoutPayload<string>()
            );

            return result;
        }
    }
}
