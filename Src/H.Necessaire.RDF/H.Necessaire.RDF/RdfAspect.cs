using System;

namespace H.Necessaire.RDF
{
    public class RdfAspect : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string DisplayLabel { get; set; }

        public RdfNode Object { get; set; }

        public RdfAspect[] Aspects { get; set; }

        public Note[] Notes { get; set; }

        public DataBin Data { get; set; }

        public RdfTriple ToTriple(RdfNode subject, params RdfAspect[] quotes)
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
                ID.ToString()
                ;
        }
    }
}