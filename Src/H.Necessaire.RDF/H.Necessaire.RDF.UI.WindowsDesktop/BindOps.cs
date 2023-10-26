namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    static class BindOps
    {
        public static double Multiply(int unit, double factor) => unit * factor;

        public static Microsoft.UI.Xaml.GridLength MultiplyForGrid(int unit, double factor) => new Microsoft.UI.Xaml.GridLength(unit * factor, Microsoft.UI.Xaml.GridUnitType.Pixel);
    }
}
