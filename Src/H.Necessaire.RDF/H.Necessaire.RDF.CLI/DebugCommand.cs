using H.Necessaire.Runtime.CLI.Commands;
using System;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.CLI
{
    internal class DebugCommand : CommandBase
    {
        public override Task<OperationResult> Run()
        {
            RdfTripleMeta simpleTriple = ("John", "is", "Awesome");

            RdfTriple<string, RdfPredicate<RdfPredicate<RdfObject<DateTime>>>, string> triple = simpleTriple.WithBody(
                "John",
                ((RdfPredicateMeta)"is").WithBody(((RdfPredicateMeta)"asOf").WithBody(((RdfObjectMeta)DateTime.Today.ToString()).WithBody(DateTime.Today))),
                "Awesome"
                );



            return OperationResult.Win().AsTask();
        }
    }
}
