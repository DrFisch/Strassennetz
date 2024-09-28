using Straßenverkehr.Infrastruktur.Helper;
using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Straßenverkehr.Infrastruktur.Strassennetzelemente;
using System;
using System.Collections.Generic;

namespace Straßenverkehr.Fahrzeuge.Vehikel
{


    public class Auto
    {
        public string Name { get; set; }
        public StrassennetzElement AktuellePosition { get; private set; }
        public StrassennetzElement VorherigePosition { get; private set; }
        public double Geschwindigkeit { get; set; }  // Geschwindigkeit in Metern pro Sekunde

        public Auto(string name, StrassennetzElement startPosition, double geschwindigkeit)
        {
            Name = name;
            AktuellePosition = startPosition;
            VorherigePosition = null;  // Initial keine vorherige Position
            Geschwindigkeit = geschwindigkeit;
            Console.WriteLine($"{Name} startet auf {AktuellePosition.Name}.");
        }

        // Methode zum Fahren zu einem benachbarten Element
        public void FahreZuNaechstemElement()
        {
            var verbindungen = VerbindungsManager.GetVerbindungen(AktuellePosition.Name);

            // Überprüfen, ob es eine Sackgasse ist (nur eine Verbindung)
            if (verbindungen.Count > 1)
            {
                // Entferne die Möglichkeit, zur vorherigen Position zurückzufahren, wenn es mehr als eine Option gibt
                verbindungen.RemoveAll(v => v.ZielElement == VorherigePosition);
            }

            if (verbindungen.Count > 0)
            {
                var naechsteVerbindung = WähleNaechsteVerbindung(verbindungen);

                // Speichern der aktuellen Position als vorherige Position
                VorherigePosition = AktuellePosition;

                // Prüfen, ob die nächste Verbindung eine Straße ist
                if (naechsteVerbindung.ZielElement is Strasse strasse)
                {
                    FahreDurchStrasse(strasse); // Fährt durch alle Straßenelemente
                }
                else
                {
                    Console.WriteLine($"{Name} fährt von {AktuellePosition.Name} zu {naechsteVerbindung.ZielElement.Name}.");
                    AktuellePosition = naechsteVerbindung.ZielElement;
                }
            }
            else
            {
                Console.WriteLine($"{Name} kann nicht weiterfahren, keine Verbindungen vorhanden.");
            }
        }

        // Methode zum Fahren durch eine Straße
        private void FahreDurchStrasse(Strasse strasse)
        {
            var aktuellesElement = strasse.Kopf;

            while (aktuellesElement != null)
            {
                double zeitInSekunden = aktuellesElement.Strassenelement.Laenge / Geschwindigkeit;
                Console.WriteLine($"{Name} fährt durch {aktuellesElement.Strassenelement.Name} ({aktuellesElement.Strassenelement.Laenge} Meter), das dauert {zeitInSekunden:F2} Sekunden.");
                Thread.Sleep((int)(zeitInSekunden * 1000));  // Wartezeit in Millisekunden
                aktuellesElement = aktuellesElement.Nächste; // Zum nächsten Straßenelement
            }

            // Nach dem Durchfahren der Straße die aktuelle Position auf die Straße setzen
            AktuellePosition = strasse;
        }

        // Methode zum zufälligen Auswählen einer Verbindung
        private Verbindung WähleNaechsteVerbindung(List<Verbindung> verbindungen)
        {
            if (verbindungen.Count == 1)
            {
                return verbindungen[0]; // Wenn es nur eine Verbindung gibt, muss das Auto diesen Weg nehmen
            }

            // Beispiel: Zufällige Auswahl einer der möglichen Verbindungen
            Random rand = new Random();
            int index = rand.Next(verbindungen.Count);

            return verbindungen[index];
        }
    }
}
