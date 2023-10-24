using H.Necessaire.Runtime.CLI.Commands;
using System.Linq;
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
                .Push(("knows", "best"))
                ;

            RdfNode awesome = (RdfNode)johnDoe.Aspects[0].Object;
            awesome.Aspects
                = awesome.Aspects
                .Push(("is", "a word"))
                .Push(("is", "in english"))
                .Push(("has", "translations"))
                ;

            ((RdfNode)awesome.Aspects.Last().Object).Aspects
                = ((RdfNode)awesome.Aspects.Last().Object).Aspects
                .Push(("are taken from", "DEX"))
                .And(x => {
                    ((RdfNode)x.Last().Object).Aspects = ((RdfNode)x.Last().Object).Aspects.Push(("quotes", ("Dictionaries", ("are", "awesome"))));
                })
                ;

            RdfGraph graph = new RdfGraph { Root = johnDoe };

            string graphPrint = graph.ToString();

            return OperationResult.Win().AsTask();
        }
    }
}
