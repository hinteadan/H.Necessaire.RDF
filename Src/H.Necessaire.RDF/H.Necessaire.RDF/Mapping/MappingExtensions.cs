using System;
using System.Collections.Generic;
using System.Linq;

namespace H.Necessaire.RDF
{
    public static class MappingExtensions
    {
        public static MultiType<RdfNode, RdfTriple>[] AsNodes(this IEnumerable<RdfTriple> rdfTriples)
        {
            if (rdfTriples?.Any(x => x != null) != true)
                return null;

            MultiType<RdfNode, RdfTriple>[] allDistinctNodes
                = rdfTriples
                .Where(x => x != null)
                .Select(x => x.AsNode())
                .GroupBy(x => {
                    Guid id;
                    x.Read(node => id = node.ID, triple => id = triple.ID);
                    return id;
                })
                .Select(x => x.Last())
                .ToArray()
                ;

            return
                allDistinctNodes;
        }
    }
}
