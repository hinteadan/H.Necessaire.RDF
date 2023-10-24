using System;
using System.Linq;

namespace H.Necessaire.RDF
{
    public class RdfTriple : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string IDTag { get; set; }

        public MultiType<RdfNode, RdfTriple> Subject { get; set; }

        public RdfAspect Aspect { get; set; }

        public MultiType<RdfNode, RdfTriple> Object => Aspect?.Object;

        public RdfAspect[] Aspects { get; set; }

        public Note[] Notes { get; set; }

        public bool IsQuoted => Aspects?.Any() == true;

        public bool IsAsserted => Aspect?.Aspects?.Any() == true;

        public MultiType<RdfNode, RdfTriple> AsNode()
        {
            return
                Subject
                ?.And(x => {
                    x.Read(
                        node => node.Aspects = node.Aspects.Push(Aspect).ToNoNullsArray(),
                        triple => triple.Aspects = triple.Aspects.Push(Aspect).ToNoNullsArray()
                    );
                });
        }

        public override string ToString()
        {
            return
                $"{Subject} {Aspect} {Object}".Trim().NullIfEmpty();
        }


        public static implicit operator RdfTriple((MultiType<RdfNode, RdfTriple>, RdfAspect) parts)
        {
            return new RdfTriple { Subject = parts.Item1, Aspect = parts.Item2 };
        }

        public static implicit operator RdfTriple((RdfNode, RdfAspect) parts)
        {
            return new RdfTriple { Subject = parts.Item1, Aspect = parts.Item2 };
        }

        public static implicit operator RdfTriple((RdfTriple, RdfAspect) parts)
        {
            return new RdfTriple { Subject = parts.Item1, Aspect = parts.Item2 };
        }
    }
}
