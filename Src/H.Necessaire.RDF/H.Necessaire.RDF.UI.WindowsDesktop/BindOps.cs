using Microsoft.UI.Xaml;

namespace H.Necessaire.RDF.UI.WindowsDesktop
{
    static class BindOps
    {
        public static double Size(int unit, double factor) => unit * factor;

        public static GridLength SizeForGrid(int unit, double factor) => new GridLength(unit * factor, GridUnitType.Pixel);

        public static Thickness SizeForThickness(int unit, double factor)
            => new Thickness(unit * factor);
        public static Thickness SizeForThickness(int vUnit, double vFactor, int hUnit, double hFactor)
            => new Thickness(hUnit * hFactor, vUnit * vFactor, hUnit * hFactor, vUnit * vFactor);

        public static Thickness SizeForThickness(int tUnit, double tFactor, int rUnit, double rFactor, int bUnit, double bFactor, int lUnit, double lFactor)
            => new Thickness(lUnit * lFactor, tUnit * tFactor, rUnit * rFactor, bUnit * bFactor);
    }
}
