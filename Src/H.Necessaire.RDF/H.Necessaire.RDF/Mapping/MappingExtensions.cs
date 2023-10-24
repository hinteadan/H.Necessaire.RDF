using System.Collections.Generic;
using System.Linq;

namespace H.Necessaire.RDF
{
    public static class MappingExtensions
    {
        public static RdfNode[] AsNodes(this IEnumerable<RdfTriple> rdfTriples)
        {
            if (rdfTriples?.Any(x => x != null) != true)
                return null;

            RdfNode[] allDistinctNodes
                = rdfTriples
                .Where(x => x != null)
                .Select(x => x.AsNode())
                .GroupBy(x => x.ID)
                .Select(x => x.Last())
                .ToArray()
                ;

            return
                allDistinctNodes;
        }
    }
}
