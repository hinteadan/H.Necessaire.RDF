using System;
using System.Linq;

namespace H.Necessaire.RDF
{
    public class RdfTriple : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public RdfNode Subject { get; set; }

        public RdfAspect Aspect { get; set; }

        public RdfNode Object => Aspect?.Object;

        public RdfAspect[] Aspects { get; set; }

        public Note[] Notes { get; set; }

        public bool IsQuoted() => Aspects?.Any() == true;

        public bool IsAsserted() => Aspect?.Aspects?.Any() == true;

        public override string ToString()
        {
            return
                $"{Subject} {Aspect} {Object}".Trim().NullIfEmpty();
        }
    }
}
