using H.Necessaire.RDF.Printing;
using System;

namespace H.Necessaire.RDF
{
    public class RdfGraph : IGuidIdentity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string IDTag { get; set; }
        public string DisplayLabel { get; set; }
        public Note[] Notes { get; set; }

        public MultiType<RdfNode, RdfTriple> Root { get; set; }


        public override string ToString()
        {
            return this.PrintGraph();
        }
    }
}
