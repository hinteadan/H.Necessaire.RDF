using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF
{
    public class RdfObject<TBody> : RdfConcreteConceptBase<TBody>
    {
        #region Construct
        public RdfObject(Func<Task<TBody>> bodyAcquirer, ImAnRdfConcept meta) : base(bodyAcquirer, meta)
        {
        }

        public RdfObject(TBody body, ImAnRdfConcept meta) : base(body, meta)
        {
        }
        #endregion

        public override RdfConceptType ConceptType { get; } = RdfConceptType.Object;
    }
}
