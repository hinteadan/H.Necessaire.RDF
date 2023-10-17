using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public abstract class RdfConceptBase<TPayload> : RdfConceptBase
    {
        protected RdfConceptBase() : base()
        {
            UpdatePayloadNotes();
        }
        protected RdfConceptBase(ImAnRdfConcept meta) : base(meta)
        {
            UpdatePayloadNotes();
        }
        public abstract Task<OperationResult<TPayload>> AcquirePayload();

        private void UpdatePayloadNotes()
        {
            PayloadType(typeof(TPayload).Name);
        }
    }
}
