using System;

namespace H.Necessaire.RDF
{
    public class RdfNode : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string DisplayLabel { get; set; }

        public RdfAspect[] Aspects { get; set; }

        public Note[] Notes { get; set; }

        public DataBin Data { get; set; }

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
