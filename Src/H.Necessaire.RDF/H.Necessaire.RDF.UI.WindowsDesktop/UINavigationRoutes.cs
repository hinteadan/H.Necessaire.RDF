using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.WellKnown;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    static class NavPath
    {
        public static readonly string Home = WellKnownPath.Home;
        public static readonly string RdfGraphDefinition = "RdfGraphDefinition";
    }

    static class UINavigationRoutes
    {
        public static readonly IDictionary<string, Func<Task<ImAUIPage>>> Routes = new Dictionary<string, Func<Task<ImAUIPage>>>{

            { NavPath.Home, () => new Pages.HomePage().AsTask<ImAUIPage>() },

            { NavPath.RdfGraphDefinition, () => new Pages.RdfGraphDefinitionPage().AsTask<ImAUIPage>() },

        };
    }
}
