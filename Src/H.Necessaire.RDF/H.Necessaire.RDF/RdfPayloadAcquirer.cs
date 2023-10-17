using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    internal class RdfPayloadAcquirer<TPayload>
    {
        #region Construct
        private readonly Func<Task<TPayload>> payloadAcquirer;
        private readonly TimeSpan payloadResultTimeout = TimeSpan.FromSeconds(15);
        private EphemeralType<OperationResult<TPayload>> payloadResult = null;
        public RdfPayloadAcquirer(Func<Task<TPayload>> payloadAcquirer)
        {
            this.payloadAcquirer = payloadAcquirer;
        }
        public RdfPayloadAcquirer(TPayload payload)
        {
            payloadResult = new EphemeralType<OperationResult<TPayload>>
            {
                Payload = payload.ToWinResult(),
                ValidFor = null,
            };
        }
        #endregion

        public async Task<OperationResult<TPayload>> AcquirePayload()
        {
            if (payloadResult is null || payloadResult.IsExpired() || payloadResult.Payload?.IsSuccessful != true)
            {
                await RefreshPayload();
            }

            return payloadResult.Payload;
        }

        private async Task RefreshPayload()
        {
            await
                new Func<Task>(async () =>
                {
                    if (payloadAcquirer is null)
                    {
                        payloadResult = new EphemeralType<OperationResult<TPayload>>
                        {
                            Payload = OperationResult.Fail($"{nameof(payloadAcquirer)} not defined").WithoutPayload<TPayload>(),
                            ValidFor = payloadResultTimeout,
                        };
                        return;
                    }

                    payloadResult = new EphemeralType<OperationResult<TPayload>>
                    {
                        Payload = (await payloadAcquirer()).ToWinResult(),
                        ValidFor = payloadResultTimeout,
                    };
                })
                .TryOrFailWithGrace(
                    onFail: ex =>
                    {
                        payloadResult = new EphemeralType<OperationResult<TPayload>>
                        {
                            Payload = OperationResult.Fail(ex, $"Error occured while trying to acquire the payload. Reason: {ex.Message}").WithoutPayload<TPayload>(),
                            ValidFor = payloadResultTimeout,
                        };
                    }
                );
        }
    }
}
