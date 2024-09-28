using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;
using Straßenverkehr.Infrastruktur.Strassennetzelemente.DoubleLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Straßenverkehr.Infrastruktur.Strassennetzelemente
{
    public class Strasse : StrassennetzElement
    {
        public List<StrassennetzElement> Verbindungen { get; } = new List<StrassennetzElement>();
        public StrassenelementKnoten Kopf { get; private set; }
        public StrassenelementKnoten Ende { get; private set; }

        public Strasse(string name) : base(name) { }

        public void AddStrassenelement(BaseStrassenelement strassenelement)
        {
            StrassenelementKnoten neuerKnoten = new StrassenelementKnoten(strassenelement);

            if (Kopf == null)
            {
                Kopf = neuerKnoten;
                Ende = neuerKnoten;
            }
            else
            {
                Ende.Nächste = neuerKnoten;
                neuerKnoten.Vorherige = Ende;
                Ende = neuerKnoten;
            }
        }

        public override void Anzeigen()
        {
            Console.WriteLine($"Strasse: {Name}");
            StrassenelementKnoten aktuellerKnoten = Kopf;
            while (aktuellerKnoten != null)
            {
                aktuellerKnoten.Strassenelement.Anzeigen();
                aktuellerKnoten = aktuellerKnoten.Nächste;
            }
        }
    }
}
