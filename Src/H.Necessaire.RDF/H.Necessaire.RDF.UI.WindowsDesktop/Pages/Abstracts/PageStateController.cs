using H.Necessaire.RDF.UI.Runtime.UIComponents;
using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace H.Necessaire.RDF.UI.WindowsDesktop.Pages.Abstracts
{
    public class PageStateController<TState> : UIComponentBase<TState> where TState : ImAUIComponentState
    {
        readonly string statePropertyName = "State";
        readonly Action<PropertyChangedEventArgs> eventRaiser;
        public PageStateController(TState initialState, Action<PropertyChangedEventArgs> eventRaiser, string statePropertyName = "State")
        {
            State = initialState;
            this.statePropertyName = statePropertyName;
            this.eventRaiser = eventRaiser;
        }
        public override async Task ApplyState(TState state)
        {
            await base.ApplyState(state);
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            eventRaiser?.Invoke(new PropertyChangedEventArgs(statePropertyName));
        }
    }
}
