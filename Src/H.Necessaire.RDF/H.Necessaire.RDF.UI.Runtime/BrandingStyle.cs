namespace H.Necessaire.RDF.UI.Runtime
{
    public class BrandingStyle : H.Necessaire.Models.Branding.BrandingStyle
    {
        public static readonly new BrandingStyle Default = new BrandingStyle();

        public override Typography Typography { get; } = new Typography(
            "'Fira Sans Light', Helvetica, Calibri, Arial, Sans-Serif",
            new TypographySize(12),
            "https://fonts.googleapis.com/css2?family=Fira+Sans:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap"
            );
    }
}
