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

            var triple = simpleTriple.WithPayload(
                "John",
                ((RdfPredicateMeta)"is").WithPayload(((RdfPredicateMeta)"asOf").WithPayload(((RdfObjectMeta)DateTime.Today.ToString()).WithPayload(DateTime.Today))),
                "Awesome"
                );



            return OperationResult.Win().AsTask();
        }
    }
}
