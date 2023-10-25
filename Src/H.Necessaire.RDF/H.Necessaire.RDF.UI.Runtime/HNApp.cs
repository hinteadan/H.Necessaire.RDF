using H.Necessaire.Runtime;

namespace H.Necessaire.RDF.UI.Runtime
{
    public class HNApp
    {
        public static readonly HNApp Licat = new HNApp(new AppWireup().WithEverything());


        public ImAnApiWireup Wireup { get; }
        public HNApp(ImAnApiWireup wireup)
        {
            this.Wireup = wireup;
        }

        public ImADependencyRegistry Ion => Wireup.DependencyRegistry;
    }
}
