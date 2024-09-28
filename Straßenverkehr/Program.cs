using Straßenverkehr.Infrastruktur.Builder;
using Straßenverkehr.Infrastruktur.Helper;
using Straßenverkehr.Infrastruktur.Strassennetzelemente.Strassenelemente;
using Straßenverkehr.Infrastruktur.Strassennetzelemente;

public class Program
{
    public static void Main()
    {
        // Erstellen eines Strassennetzes mit dem Builder
        var strassennetzBuilder = new StrassenNetzBuilder();

        // Zuerst die Strassen erstellen und im Builder speichern
        strassennetzBuilder
            .AddStrasse("Strasse 1", strasse =>
            {
                strasse.AddKurve("Kurve 1a")
                       .AddGerade("Gerade 1a")
                       .AddKurve("Kurve 2a");
            })
            .AddStrasse("Strasse 2", strasse =>
            {
                strasse.AddGerade("Gerade 1b");
            })
            .AddStrasse("Strasse 3", strasse =>
            {
                strasse.AddKurve("Kurve 1c")
                       .AddGerade("Gerade 1c")
                       .AddKurve("Kurve 2c");
            });

        // Kreuzung A Verbindungen
        strassennetzBuilder
            .AddKreuzung("Kreuzung A", kreuzung =>
            {
                var parkplatzA = new Parkplatz("Parkplatz A");
                kreuzung.AddVerbindung(parkplatzA);  // Verbindung zu Parkplatz A

                // Hier wird dieselbe Straße 1 verwendet, die vorher erstellt wurde
                var strasse1 = strassennetzBuilder.GetStrasse("Strasse 1"); // Hole die Straße 1 aus dem Builder
                var kurve1a = strasse1.Kopf.Strassenelement as Kurve;  // Hole das erste Straßenelement (Kurve 1)
                kreuzung.AddVerbindung(strasse1, kurve1a);  // Verbindung zu Kurve 1 der Strasse 1

                var strasse2 = strassennetzBuilder.GetStrasse("Strasse 2");
                var gerade2a = strasse2.Kopf.Strassenelement as Gerade;  // Hole das erste Straßenelement (Gerade 1)
                kreuzung.AddVerbindung(strasse2, gerade2a);  // Verbindung zu Strasse 2

                var strasse3 = strassennetzBuilder.GetStrasse("Strasse 3");
                var kurve3a = strasse3.Kopf.Strassenelement as Kurve;  // Hole das erste Straßenelement (Kurve 1)
                kreuzung.AddVerbindung(strasse3, kurve3a);  // Verbindung zu Strasse 3
            })

            // Kreuzung B Verbindungen
            .AddKreuzung("Kreuzung B", kreuzung =>
            {
                var parkplatzB = new Parkplatz("Parkplatz B");
                kreuzung.AddVerbindung(parkplatzB);  // Verbindung zu Parkplatz B

                var strasse1 = strassennetzBuilder.GetStrasse("Strasse 1");
                var kurve1b = strasse1.Ende.Strassenelement as Kurve;  // Hole das letzte Straßenelement (Kurve 2)
                kreuzung.AddVerbindung(strasse1, kurve1b);  // Verbindung zu Kurve 2 der Strasse 1

                var strasse2 = strassennetzBuilder.GetStrasse("Strasse 2");
                var gerade2b = strasse2.Kopf.Strassenelement as Gerade;  // Verbinde dasselbe erste Straßenelement (Gerade 1)
                kreuzung.AddVerbindung(strasse2, gerade2b);  // Verbindung zu Strasse 2

                var strasse3 = strassennetzBuilder.GetStrasse("Strasse 3");
                var kurve3b = strasse3.Ende.Strassenelement as Kurve;  // Hole das letzte Straßenelement (Kurve 2)
                kreuzung.AddVerbindung(strasse3, kurve3b);  // Verbindung zu Kurve 2 der Strasse 3
            })

            .Build();

        // Ausgabe des Strassennetzes und der Verbindungen
        var strassennetz = strassennetzBuilder.Build();
        strassennetz.Anzeigen();
        VerbindungsManager.Anzeigen();
    }

}