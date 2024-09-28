using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Straßenverkehr.Infrastruktur.Strassennetzelemente
{
    public class Parkplatz : StrassennetzElement
    {
        public Parkplatz(string name) : base(name) { }

        public override void Anzeigen()
        {
            Console.WriteLine($"Parkplatz: {Name}");
        }
    }

}
