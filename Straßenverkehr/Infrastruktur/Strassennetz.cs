using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;
using Straßenverkehr.Infrastruktur.Builder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Straßenverkehr.Infrastruktur.Strassennetzelemente;

namespace Straßenverkehr.Infrastruktur
{
    public class StrassenNetz
    {
        private readonly Dictionary<string, Strasse> _strassen = new Dictionary<string, Strasse>();
        private readonly Dictionary<string, Parkplatz> _parkplaetze = new Dictionary<string, Parkplatz>();
        public List<StrassennetzElement> Elemente { get; } = new List<StrassennetzElement>();

        // Fügt ein StrassennetzElement hinzu
        public void AddElement(StrassennetzElement element)
        {
            Elemente.Add(element);

            // Speichere Straßen und Parkplätze
            if (element is Strasse strasse)
            {
                _strassen[strasse.Name] = strasse;
            }
            else if (element is Parkplatz parkplatz)
            {
                _parkplaetze[parkplatz.Name] = parkplatz;
            }
        }

        // Gibt eine gespeicherte Straße zurück
        public Strasse GetStrasse(string name)
        {
            if (_strassen.ContainsKey(name))
            {
                return _strassen[name];
            }
            throw new Exception($"Strasse {name} nicht gefunden.");
        }

        // Gibt einen gespeicherten Parkplatz zurück
        public Parkplatz GetParkplatz(string name)
        {
            if (_parkplaetze.ContainsKey(name))
            {
                return _parkplaetze[name];
            }
            throw new Exception($"Parkplatz {name} nicht gefunden.");
        }

        // Ausgabe des gesamten Strassennetzes
        public void Anzeigen()
        {
            Console.WriteLine("Strassennetz:");
            foreach (var element in Elemente)
            {
                element.Anzeigen();
            }
        }
        public void AnzeigenAlleElemente()
        {
            Console.WriteLine("Alle gespeicherten Elemente im Strassennetz:");
            foreach (var element in Elemente)
            {
                Console.WriteLine($"- {element.GetType().Name}: {element.Name}");
            }
        }
    }

}
