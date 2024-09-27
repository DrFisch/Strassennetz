using Straßenverkehr.Strassennetzelemente.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Straßenverkehr.Strassennetzelemente
{
    public class Kreuzung : StrassennetzElement
    {
        public List<StrassennetzElement> Verbindungen { get; } = new List<StrassennetzElement>();

        public Kreuzung(string name) : base(name) { }

        // Fügt eine Verbindung zu einem anderen StrassennetzElement (z. B. Parkplatz, Strasse) hinzu
        public void AddVerbindung(StrassennetzElement element)
        {
            Verbindungen.Add(element);
        }

        public override void Anzeigen()
        {
            Console.WriteLine($"Kreuzung: {Name}");
            foreach (var verbindung in Verbindungen)
            {
                Console.WriteLine($"  Verbindung zu: {verbindung.Name}");
            }
        }
    }

}
