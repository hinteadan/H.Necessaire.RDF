using System;

namespace H.Necessaire.RDF
{
    public class RdfTriple : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public RdfNode Subject { get; set; }

        public RdfAspect Aspect { get; set; }

        public RdfNode Object => Aspect?.Object;

        public override string ToString()
        {
            return
                $"{Subject} {Aspect} {Object}".Trim().NullIfEmpty();
        }
    }
}
