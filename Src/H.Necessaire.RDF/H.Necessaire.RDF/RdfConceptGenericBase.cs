using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public abstract class RdfConceptBase<TBody> : RdfConceptBase
    {
        protected RdfConceptBase() : base()
        {
            UpdateBodyNotes();
        }
        protected RdfConceptBase(ImAnRdfConcept meta) : base(meta)
        {
            UpdateBodyNotes();
        }
        public abstract Task<OperationResult<TBody>> AcquireBody();

        private void UpdateBodyNotes()
        {
            BodyType(typeof(TBody).Name);
        }
    }
}
