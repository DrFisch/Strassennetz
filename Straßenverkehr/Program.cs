using Straßenverkehr.Builder;
using Straßenverkehr.Helper;
using Straßenverkehr.Strassennetzelemente;
using Straßenverkehr.Strassennetzelemente.Strassenelemente;

public class Program
{
    public static void Main()
    {
        // Erstellen eines Strassennetzes mit dem Builder
        // Erstellen eines Strassennetzes mit dem Builder
        var strassennetz = new StrassenNetzBuilder()
            // Kreuzung A Verbindungen
            .AddKreuzung("Kreuzung A", kreuzung =>
            {
                var parkplatzA = new Parkplatz("Parkplatz A");
                kreuzung.AddVerbindung(parkplatzA);  // Verbindung zu Parkplatz A

                var strasse1 = new Strasse("Strasse 1");
                var kurve1a = new Kurve("Kurve 1");
                kreuzung.AddVerbindung(strasse1, kurve1a);  // Verbindung zu Strasse 1

                var strasse2 = new Strasse("Strasse 2");
                var gerade2a = new Gerade("Gerade 1");
                kreuzung.AddVerbindung(strasse2, gerade2a);  // Verbindung zu Strasse 2

                var strasse3 = new Strasse("Strasse 3");
                var kurve3a = new Kurve("Kurve 1");
                kreuzung.AddVerbindung(strasse3, kurve3a);  // Verbindung zu Strasse 3
            })

            // Kreuzung B Verbindungen
            .AddKreuzung("Kreuzung B", kreuzung =>
            {
                var parkplatzB = new Parkplatz("Parkplatz B");
                kreuzung.AddVerbindung(parkplatzB);  // Verbindung zu Parkplatz B

                var strasse1 = new Strasse("Strasse 1");
                var kurve1b = new Kurve("Kurve 2");
                kreuzung.AddVerbindung(strasse1, kurve1b);  // Verbindung zu Strasse 1

                var strasse2 = new Strasse("Strasse 2");
                var gerade2b = new Gerade("Gerade 2");
                kreuzung.AddVerbindung(strasse2, gerade2b);  // Verbindung zu Strasse 2

                var strasse3 = new Strasse("Strasse 3");
                var kurve3b = new Kurve("Kurve 2");
                kreuzung.AddVerbindung(strasse3, kurve3b);  // Verbindung zu Strasse 3
            })

            // Aufbau der Strassen
            .AddStrasse("Strasse 1", strasse =>
            {
                strasse.AddKurve("Kurve 1")
                       .AddGerade("Gerade 1")
                       .AddKurve("Kurve 2");
            })
            .AddStrasse("Strasse 2", strasse =>
            {
                strasse.AddGerade("Gerade 1");
            })
            .AddStrasse("Strasse 3", strasse =>
            {
                strasse.AddKurve("Kurve 1")
                       .AddGerade("Gerade 1")
                       .AddKurve("Kurve 2");
            })
            .Build();


        // Ausgabe des Strassennetzes und der Verbindungen
        strassennetz.Anzeigen();
        VerbindungsManager.Anzeigen();
    }
}