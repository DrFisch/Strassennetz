using Straßenverkehr.Helper;
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
        public Kreuzung(string name) : base(name) { }

        // Fügt eine bidirektionale Verbindung zu einem anderen StraßennetzElement oder einem Straßenelement hinzu
        public void AddVerbindung(StrassennetzElement element, BaseStrassenelement strassenelement = null)
        {
            // Verbindung von Kreuzung zu Element
            if (strassenelement != null)
            {
                VerbindungsManager.AddVerbindung(this.Name, new Verbindung(element, strassenelement));
                VerbindungsManager.AddVerbindung(element.Name, new Verbindung(this, strassenelement));
            }
            else
            {
                VerbindungsManager.AddVerbindung(this.Name, new Verbindung(element));
                VerbindungsManager.AddVerbindung(element.Name, new Verbindung(this));
            }
        }

        public override void Anzeigen()
        {
            Console.WriteLine($"Kreuzung: {Name}");
        }
    }

}
