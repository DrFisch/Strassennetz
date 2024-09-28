using Straßenverkehr.Infrastruktur.Builder;
using Straßenverkehr.Infrastruktur.Helper;
using Straßenverkehr.Infrastruktur.Strassennetzelemente.Strassenelemente;
using Straßenverkehr.Infrastruktur.Strassennetzelemente;
using Straßenverkehr.Fahrzeuge.Vehikel;

public class Program
{
    public static void Main()
    {
        // Erstellen eines Strassennetzes mit dem Builder
        var strassennetzBuilder = new StrassenNetzBuilder();

        // Erstellen der Straßen
        strassennetzBuilder
            .AddStrasse("Strasse 1", strasse =>
            {
                strasse.AddKurve("Kurve 1a", 50)
                       .AddGerade("Gerade 1a", 80)
                       .AddKurve("Kurve 1b", 50);
            })
            .AddStrasse("Strasse 2", strasse =>
            {
                strasse.AddGerade("Gerade 2a", 80);
            })
            .AddStrasse("Strasse 3", strasse =>
            {
                strasse.AddKurve("Kurve 3a", 50)
                       .AddGerade("Gerade 3a", 80)
                       .AddKurve("Kurve 3b", 50);
            })

            // Erstellen des Parkplatzes A
            .AddParkplatz("Parkplatz A")
            // Erstellen des Parkplatzes B
            .AddParkplatz("Parkplatz B");

        // Erstellen der Kreuzungen und Verbindungen
        strassennetzBuilder
            // Kreuzung A Verbindungen
            .AddKreuzung("Kreuzung A", kreuzung =>
            {
                var parkplatzA = strassennetzBuilder.GetParkplatz("Parkplatz A");  // Abrufen von Parkplatz A
                kreuzung.AddVerbindung(parkplatzA);  // Verbindung zu Parkplatz A

                // Verbindung zu Straße 1 (Kurve 1a)
                var strasse1 = strassennetzBuilder.GetStrasse("Strasse 1");  // Abrufen von Straße 1
                var kurve1a = strasse1.Kopf.Strassenelement as Kurve;  // Anfangselement von Strasse 1
                kreuzung.AddVerbindung(strasse1, kurve1a);

                // Verbindung zu Straße 2 (Gerade 2a)
                var strasse2 = strassennetzBuilder.GetStrasse("Strasse 2");  // Abrufen von Straße 2
                var gerade2a = strasse2.Kopf.Strassenelement as Gerade;  // Anfangs- und Endelement von Strasse 2
                kreuzung.AddVerbindung(strasse2, gerade2a);

                // Verbindung zu Straße 3 (Kurve 3a)
                var strasse3 = strassennetzBuilder.GetStrasse("Strasse 3");  // Abrufen von Straße 3
                var kurve3a = strasse3.Kopf.Strassenelement as Kurve;  // Anfangselement von Strasse 3
                kreuzung.AddVerbindung(strasse3, kurve3a);
            })

            // Kreuzung B Verbindungen
            .AddKreuzung("Kreuzung B", kreuzung =>
            {
                var parkplatzB = strassennetzBuilder.GetParkplatz("Parkplatz B");  // Abrufen von Parkplatz B
                kreuzung.AddVerbindung(parkplatzB);  // Verbindung zu Parkplatz B

                // Verbindung zu Straße 1 (Kurve 1b)
                var strasse1 = strassennetzBuilder.GetStrasse("Strasse 1");  // Abrufen von Straße 1
                var kurve1b = strasse1.Ende.Strassenelement as Kurve;  // Endelement von Strasse 1
                kreuzung.AddVerbindung(strasse1, kurve1b);

                // Verbindung zu Straße 2 (Gerade 2a)
                var strasse2 = strassennetzBuilder.GetStrasse("Strasse 2");  // Abrufen von Straße 2
                var gerade2a = strasse2.Kopf.Strassenelement as Gerade;  // Anfangs- und Endelement von Strasse 2
                kreuzung.AddVerbindung(strasse2, gerade2a);

                // Verbindung zu Straße 3 (Kurve 3b)
                var strasse3 = strassennetzBuilder.GetStrasse("Strasse 3");  // Abrufen von Straße 3
                var kurve3b = strasse3.Ende.Strassenelement as Kurve;  // Endelement von Strasse 3
                kreuzung.AddVerbindung(strasse3, kurve3b);
            });

        // Bauen des Netzes
        var strassennetz = strassennetzBuilder.Build();

        // Ausgabe des Straßennetzes
        //strassennetz.AnzeigenAlleElemente();
        VerbindungsManager.Anzeigen();

        // Beispiel für ein Auto, das auf Parkplatz A startet
        var parkplatzA = strassennetz.GetParkplatz("Parkplatz A");
        var auto = new Auto("Auto 1", parkplatzA, 25);

        // Auto fährt zur nächsten Verbindung
        for (int i = 0; i < 100; i++)
        {
            auto.FahreZuNaechstemElement();  // Auto fährt zur nächsten Verbindung
            Thread.Sleep(1000);  // Warte 1 Sekunde
        }
    }
}  

