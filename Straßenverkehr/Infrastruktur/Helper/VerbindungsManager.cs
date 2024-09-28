using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Infrastruktur.Helper
{
    public static class VerbindungsManager
    {
        public static Dictionary<string, List<Verbindung>> Verbindungen { get; } = new Dictionary<string, List<Verbindung>>();

        public static void AddVerbindung(string elementName, Verbindung verbindung)
        {
            if (!Verbindungen.ContainsKey(elementName))
            {
                Verbindungen[elementName] = new List<Verbindung>();
            }
            Verbindungen[elementName].Add(verbindung);
        }

        // Gibt alle möglichen Verbindungen für ein bestimmtes Element zurück
        public static List<Verbindung> GetVerbindungen(string elementName)
        {
            if (Verbindungen.ContainsKey(elementName))
            {
                return Verbindungen[elementName];
            }
            return new List<Verbindung>();
        }

        public static void Anzeigen()
        {
            Console.WriteLine("Verbindungen:");
            foreach (var element in Verbindungen)
            {
                Console.WriteLine($"{element.Key}:");
                foreach (var verbindung in element.Value)
                {
                    if (verbindung.Strassenelement != null)
                    {
                        Console.WriteLine($"  Verbunden mit: {verbindung.ZielElement.Name}, über Straßenelement: {verbindung.Strassenelement.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"  Verbunden mit: {verbindung.ZielElement.Name}");
                    }
                }
            }
        }
    }

}
