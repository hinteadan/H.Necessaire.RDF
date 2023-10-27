namespace H.Necessaire.RDF.UI.Runtime.Managers
{
    internal class AppStateManager : ImADependency
    {
        #region Construct
        HNAppState appState;
        public void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            appState = dependencyProvider.Get<HNAppState>();
        }
        #endregion
    }
}
