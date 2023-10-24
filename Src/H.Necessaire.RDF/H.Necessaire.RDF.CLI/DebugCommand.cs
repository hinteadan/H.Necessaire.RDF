using H.Necessaire.Runtime.CLI.Commands;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.CLI
{
    internal class DebugCommand : CommandBase
    {
        public override Task<OperationResult> Run()
        {
            RdfNode johnDoe = "John Doe";
            johnDoe.Aspects
                = johnDoe.Aspects
                .Push(("is", "awesome"))
                .Push(("has", "money"))
                ;

            RdfNode awesome = johnDoe.Aspects[0].Object;
            awesome.Aspects
                = awesome.Aspects
                .Push(("is", "a word"))
                .Push(("is", "in english"))
                .Push(("has", "translations"))
                ;

            RdfTriple[] triples =
                johnDoe
                .TriplesFor("is", "has")
                ;

            RdfNode[] nodes = triples.AsNodes();

            return OperationResult.Win().AsTask();
        }
    }
}
