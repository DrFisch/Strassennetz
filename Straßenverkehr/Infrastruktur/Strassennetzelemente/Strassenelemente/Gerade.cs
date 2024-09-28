using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Straßenverkehr.Infrastruktur.Strassennetzelemente.Strassenelemente
{

    public class Gerade : BaseStrassenelement
    {
        public Gerade(string name, double laenge) : base(name, laenge) { }

        public override void Anzeigen()
        {
            Console.WriteLine($"Gerade: {Name}, Länge: {Laenge} Meter");
        }
    }
}
