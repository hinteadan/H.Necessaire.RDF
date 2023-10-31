using H.Necessaire.RDF.UI.Runtime.UIComponents.Abstracts;
using System;

namespace H.Necessaire.RDF.UI.Runtime.UIComponents.Concrete
{
    public class UIPageComposer : UIPageBase
    {
        public UIPageComposer(Type ownerType) : base(ownerType)
        {
        }
    }

    public class UIPageComposer<TState> : UIPageBase<TState> where TState : ImAUIComponentState
    {
        public UIPageComposer(Type ownerType) : base(ownerType)
        {
        }
    }
}
