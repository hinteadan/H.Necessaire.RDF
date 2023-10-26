using H.Necessaire.Models.Branding;
using H.Necessaire.Runtime;

namespace H.Necessaire.RDF.UI.Runtime
{
    public class HNApp
    {
        public static readonly HNApp Lication = new HNApp(new AppWireup().WithEverything());

        public HNApp(ImAnApiWireup wireup)
        {
            this.Wireup = wireup;
        }

        public ImAnApiWireup Wireup { get; }
        public BrandingStyle Branding { get; } = BrandingStyle.Default;
        public ImADependencyRegistry Deps => Wireup.DependencyRegistry;
    }
}
