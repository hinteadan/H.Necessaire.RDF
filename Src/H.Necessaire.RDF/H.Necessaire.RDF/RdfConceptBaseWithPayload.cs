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

        public string PayloadType() => Notes.Get(WellKnownRdfNote.PayloadType);
        public string PayloadID() => Notes.Get(WellKnownRdfNote.PayloadID);

        private void UpdatePayloadNotes()
        {
            Notes = typeof(TPayload).TypeName().NoteAs(WellKnownRdfNote.PayloadType).AsArray();
        }
    }
}
