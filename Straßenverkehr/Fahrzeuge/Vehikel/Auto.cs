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

        public Auto(string name, StrassennetzElement startPosition)
        {
            Name = name;
            AktuellePosition = startPosition;
            Console.WriteLine($"{Name} startet auf {AktuellePosition.Name}.");
        }

        // Methode zum Fahren zu einem benachbarten Element
        public void FahreZuNaechstemElement()
        {
            var verbindungen = VerbindungsManager.GetVerbindungen(AktuellePosition.Name);

            if (verbindungen.Count > 0)
            {
                var naechsteVerbindung = WähleNaechsteVerbindung(verbindungen);

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
                Console.WriteLine($"{Name} fährt durch {aktuellesElement.Strassenelement.Name} auf {strasse.Name}.");
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
                return verbindungen[0]; // Wenn es nur eine Verbindung gibt
            }

            // Beispiel: Zufällige Auswahl einer der möglichen Verbindungen
            Random rand = new Random();
            int index = rand.Next(verbindungen.Count);

            return verbindungen[index];
        }
    }

}
