using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    internal class RdfBodyAcquirer<TBody>
    {
        #region Construct
        private readonly Func<Task<TBody>> bodyAcquirer;
        private readonly TimeSpan bodyResultTimeout = TimeSpan.FromSeconds(15);
        private EphemeralType<OperationResult<TBody>> bodyResult = null;
        public RdfBodyAcquirer(Func<Task<TBody>> bodyAcquirer)
        {
            this.bodyAcquirer = bodyAcquirer;
        }
        public RdfBodyAcquirer(TBody body)
        {
            bodyResult = new EphemeralType<OperationResult<TBody>>
            {
                Payload = body.ToWinResult(),
                ValidFor = null,
            };
        }
        #endregion

        public async Task<OperationResult<TBody>> AcquireBody()
        {
            if (bodyResult is null || bodyResult.IsExpired() || bodyResult.Payload?.IsSuccessful != true)
            {
                await RefreshBody();
            }

            return bodyResult.Payload;
        }

        private async Task RefreshBody()
        {
            await
                new Func<Task>(async () =>
                {
                    if (bodyAcquirer is null)
                    {
                        bodyResult = new EphemeralType<OperationResult<TBody>>
                        {
                            Payload = OperationResult.Fail($"{nameof(bodyAcquirer)} not defined").WithoutPayload<TBody>(),
                            ValidFor = bodyResultTimeout,
                        };
                        return;
                    }

                    bodyResult = new EphemeralType<OperationResult<TBody>>
                    {
                        Payload = (await bodyAcquirer()).ToWinResult(),
                        ValidFor = bodyResultTimeout,
                    };
                })
                .TryOrFailWithGrace(
                    onFail: ex =>
                    {
                        bodyResult = new EphemeralType<OperationResult<TBody>>
                        {
                            Payload = OperationResult.Fail(ex, $"Error occured while trying to acquire the payload. Reason: {ex.Message}").WithoutPayload<TBody>(),
                            ValidFor = bodyResultTimeout,
                        };
                    }
                );
        }
    }
}
