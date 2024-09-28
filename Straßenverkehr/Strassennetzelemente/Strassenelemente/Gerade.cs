using Straßenverkehr.Strassennetzelemente.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Straßenverkehr.Strassennetzelemente.Strassenelemente
{

    public class Gerade : BaseStrassenelement
    {
        public Gerade(string name) : base(name) { }

        public override void Anzeigen()
        {
            Console.WriteLine($"Gerade: {Name}");
        }
    }
}
