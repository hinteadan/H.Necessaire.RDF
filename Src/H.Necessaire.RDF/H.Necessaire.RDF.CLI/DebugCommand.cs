using H.Necessaire.Runtime.CLI.Commands;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.CLI
{
    internal class DebugCommand : CommandBase
    {
        public override Task<OperationResult> Run()
        {
            RdfTripleMeta simpleTriple = ("John", "is", "Awesome");



            return OperationResult.Win().AsTask();
        }
    }
}
