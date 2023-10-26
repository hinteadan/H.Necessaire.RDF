namespace H.Necessaire.RDF.UI.Runtime
{
    internal static class AppConfig
    {
        public static readonly RuntimeConfig Debug = new RuntimeConfig
        {
            Values = new[] {
                "App".ConfigWith(
                    "Name".ConfigWith("H.Necessaire.RDF")
                    , "DisplayName".ConfigWith("H.Necessaire's RDF UI Tools")
                    , "Copyright".ConfigWith("Copyright © {year}. H.Necessaire.RDF; by Hintea Dan Alexandru. All rights reserved. {version}")
                )
                , "Formatting".ConfigWith(
                      "DateAndTime".ConfigWith("ddd, MMM dd, yyyy 'at' HH:mm 'UTC'")
                    , "Date".ConfigWith("ddd, MMM dd, yyyy")
                    , "Time".ConfigWith("HH:mm")
                    , "Month".ConfigWith("yyyy MMM")
                    , "DayOfWeek".ConfigWith("dddd")
                    , "TimeStampThisYear".ConfigWith("MMM dd 'at' HH:mm")
                    , "TimeStampOtherYear".ConfigWith("MMM dd, yyyy 'at' HH:mm")
                    , "TimeStampIdentifier".ConfigWith("yyyyMMdd_HHmmss")
                )
            },

        };
    }
}
