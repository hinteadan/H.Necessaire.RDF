using H.Necessaire.Runtime;
using H.Necessaire.Runtime.Wireup.Abstracts;

namespace H.Necessaire.RDF.UI.Runtime
{
    internal class AppWireup : ApiWireupBase
    {
        public override ImAnApiWireup WithEverything()
        {
            ImAnApiWireup wireup =
                base
                .WithEverything()
                .With(x => x.Register<RuntimeConfig>(() => AppConfig.Debug))
                .With(x => x.Register<AppDependencyGroup>(() => new AppDependencyGroup()))
                //.With(x => x.Register<SqlServerRuntimeDependencyGroup>(() => new SqlServerRuntimeDependencyGroup()))
                //.With(x => x.Register<RavenDbRuntimeDependencyGroup>(() => new RavenDbRuntimeDependencyGroup()))
                ;

            ImALogProcessorRegistry logProcessorRegistry = wireup.DependencyRegistry.Get<ImALogProcessorRegistry>();
            foreach (ImALogProcessor logProcessor in logProcessorRegistry.GetAllKnownProcessors())
            {
                logProcessor.ConfigWith(LogConfig.Everything);
            }
            

            return wireup;
        }
    }
}
