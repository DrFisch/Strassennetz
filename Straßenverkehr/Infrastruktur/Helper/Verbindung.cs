using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;
using Straßenverkehr.Infrastruktur.Strassennetzelemente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Infrastruktur.Helper
{
    public class Verbindung
    {
        public StrassennetzElement ZielElement { get; }
        public BaseStrassenelement Strassenelement { get; }

        // Verbindung zwischen zwei Straßennetzelementen
        public Verbindung(StrassennetzElement zielElement)
        {
            ZielElement = zielElement;
            Strassenelement = null;  // Keine Verbindung über ein spezifisches Straßenelement
        }

        // Verbindung zwischen einem Straßennetzelement und einem Straßenelement
        public Verbindung(StrassennetzElement zielElement, BaseStrassenelement strassenelement)
        {
            ZielElement = zielElement;
            Strassenelement = strassenelement;
        }
    }
}
