using System;

namespace H.Necessaire.RDF
{
    public class RdfAspect : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string IDTag { get; set; }

        public string DisplayLabel { get; set; }

        public MultiType<RdfNode, RdfTriple> Object { get; set; }

        public RdfAspect[] Aspects { get; set; }

        public Note[] Notes { get; set; }

        public DataBin Data { get; set; }

        public RdfTriple ToTriple(MultiType<RdfNode, RdfTriple> subject, params RdfAspect[] quotes)
        {
            return
                new RdfTriple
                {
                    Subject = subject,
                    Aspect = this,
                    Aspects = quotes.ToNoNullsArray(),
                };
        }

        public override string ToString()
        {
            return
                DisplayLabel.NullIfEmpty()
                ??
                IDTag.NullIfEmpty()
                ??
                ID.ToString()
                ;
        }


        public static implicit operator RdfAspect((string, RdfNode) parts)
        {
            return new RdfAspect { IDTag = parts.Item1, Object = parts.Item2 };
        }
    }
}