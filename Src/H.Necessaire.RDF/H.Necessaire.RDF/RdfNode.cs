using System;
using System.Linq;

namespace H.Necessaire.RDF
{
    public class RdfNode : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string DisplayLabel { get; set; }

        public RdfAspect[] Aspects { get; set; }

        public Note[] Notes { get; set; }

        public DataBin Data { get; set; }

        public RdfTriple TripleFor(Guid aspectID, params RdfAspect[] quotes)
        {
            RdfAspect aspect = Aspects?.LastOrDefault(x => x.ID == aspectID);
            if (aspect is null)
                return null;

            return
                new RdfTriple
                {
                    Subject = this,
                    Aspect = aspect,
                    Aspects = quotes.ToNoNullsArray(),
                };
        }

        public override string ToString()
        {
            return
                DisplayLabel.NullIfEmpty()
                ??
                ID.ToString()
                ;
        }
    }
}
