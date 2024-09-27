using Straßenverkehr.Builder;
using Straßenverkehr.Strassennetzelemente;

public class Program
{
    public static void Main()
    {
        // Erstellen eines Strassennetzes mit dem Builder
        var strassennetz = new StrassenNetzBuilder()
            .AddKreuzung("Kreuzung A", kreuzung =>
            {
                // Verbindungen von Kreuzung A zu drei Strassen
                kreuzung.AddVerbindung(new Strasse("Strasse 1"));
                kreuzung.AddVerbindung(new Strasse("Strasse 2"));
                kreuzung.AddVerbindung(new Strasse("Strasse 3"));
            })
            .AddKreuzung("Kreuzung B")
            .AddStrasse("Strasse 1", strasse =>
            {
                strasse.AddKurve("Kurve 1")
                       .AddGerade("Gerade 1")
                       .AddKurve("Kurve 2")
                       .AddVerbindung(new Kreuzung("Kreuzung B"));
            })
            .AddStrasse("Strasse 2", strasse =>
            {
                strasse.AddGerade("Gerade 2")
                       .AddVerbindung(new Kreuzung("Kreuzung B"));
            })
            .AddStrasse("Strasse 3", strasse =>
            {
                strasse.AddKurve("Kurve 3")
                       .AddGerade("Gerade 3")
                       .AddKurve("Kurve 4")
                       .AddVerbindung(new Kreuzung("Kreuzung B"));
            })
            .Build();

        // Ausgabe des Strassennetzes
        strassennetz.Anzeigen();
    }
}