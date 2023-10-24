using System.Linq;
using System.Text;

namespace H.Necessaire.RDF.Printing
{
    internal static class PrintingExtensions
    {
        const string indentUnit = "    ";
        const string subIndentUnit = "  ";

        public static string PrintGraph(this RdfGraph rdfGraph)
        {
            if (rdfGraph is null)
                return null;

            if (rdfGraph.Root is null)
                return null;

            return
                PrintNodeAndChildren(rdfGraph.Root)
                .ToString()
                .NullIfEmpty()
                ;
        }

        private static StringBuilder PrintNodeAndChildren(MultiType<RdfNode, RdfTriple> node, uint depth = 0, StringBuilder printer = null)
        {
            printer = printer ?? new StringBuilder();

            if (node is null)
                return printer;

            if((RdfNode)node is null && (RdfTriple)node is null)
                return printer;

            if(depth > 0)
            {
                if (((RdfNode)node)?.Aspects.ToNoNullsArray()?.Any() != true && ((RdfTriple)node)?.Aspects.ToNoNullsArray()?.Any() != true)
                    return printer;
            }

            printer
                .Append(IndentationFor(depth))
                .Append(depth == 0 ? string.Empty : subIndentUnit)
                .Append(node)
                .AppendLine()
                ;

            RdfAspect[] aspects = (((RdfNode)node)?.Aspects ?? ((RdfTriple)node)?.Aspects).ToNoNullsArray();

            if(aspects?.Any() == true)
            {
                foreach(RdfAspect aspect in aspects)
                {
                    printer
                        .Append(IndentationFor(depth + 1))
                        .Append(aspect)
                        .Append(" ")
                        .Append(aspect.Object)
                        .AppendLine()
                        ;
                    PrintNodeAndChildren(aspect.Object, depth + 1, printer);
                }
            }


            return printer;
        }

        private static string IndentationFor(uint depth)
        {
            if (depth == 0)
                return null;

            return
                new StringBuilder()
                .And(x =>
                {
                    for(uint i = 0; i < depth; i++)
                    {
                        x.Append(indentUnit);
                    }
                })
                .ToString();

        }
    }
}
