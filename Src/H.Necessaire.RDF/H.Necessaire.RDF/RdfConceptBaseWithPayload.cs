using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public abstract class RdfConceptBase<TPayload> : RdfConceptBase
    {
        protected RdfConceptBase() : base() { }
        protected RdfConceptBase(ImAnRdfConcept meta) : base(meta) { }
        public abstract Task<OperationResult<TPayload>> AcquirePayload();
    }
}
