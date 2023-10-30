using System;
using System.Collections.Generic;
using System.Text;

namespace H.Necessaire.RDF.UI.Runtime.UINavigation
{
    public class UINavigationParams
    {
        public static readonly UINavigationParams None = new UINavigationParams(null);

        private readonly Dictionary<string, object> parameters;

        public UINavigationParams(Dictionary<string, object> parameters)
        {
            this.parameters = parameters ?? new Dictionary<string, object>();
        }

        public UINavigationParams(object parameter)
            : this(new Dictionary<string, object>() { { string.Empty, parameter } })
        { }

        public T GetValueFor<T>(string parameter, Action orFail = null)
        {
            if (!parameters.ContainsKey(parameter))
            {
                orFail?.Invoke();
                return default(T);
            }

            object value = parameters[parameter];

            if (!(value is T))
            {
                orFail?.Invoke();
                return default(T);
            }

            return (T)value;
        }

        public T GetValue<T>(Action orFail = null) => GetValueFor<T>(string.Empty, orFail);
    }
}
