using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public class RdfSubject<TBody> : RdfConcreteConceptBase<TBody>
    {
        #region Construct
        public RdfSubject(Func<Task<TBody>> bodyAcquirer, ImAnRdfConcept meta) : base(bodyAcquirer, meta)
        {
        }

        public RdfSubject(TBody body, ImAnRdfConcept meta) : base(body, meta)
        {
        }
        #endregion

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Subject;
    }
}
