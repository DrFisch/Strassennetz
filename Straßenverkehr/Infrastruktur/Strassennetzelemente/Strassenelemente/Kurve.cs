using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;

namespace Straßenverkehr.Infrastruktur.Strassennetzelemente.Strassenelemente
{
    public class Kurve : BaseStrassenelement
    {
        public Kurve(string name, double laenge) : base(name, laenge) { }

        public override void Anzeigen()
        {
            Console.WriteLine($"Kurve: {Name}, Länge: {Laenge} Meter");
        }
    }
}
