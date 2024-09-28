using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;

namespace Straßenverkehr.Infrastruktur.Strassennetzelemente.DoubleLinkedList
{
    public class StrassenelementKnoten
    {
        public BaseStrassenelement Strassenelement { get; set; }
        public StrassenelementKnoten Nächste { get; set; }
        public StrassenelementKnoten Vorherige { get; set; }

        public StrassenelementKnoten(BaseStrassenelement strassenelement)
        {
            Strassenelement = strassenelement;
        }
    }

}
