using Straßenverkehr.Helper;
using Straßenverkehr.Strassennetzelemente;
using Straßenverkehr.Strassennetzelemente.Abstract;
using Straßenverkehr.Strassennetzelemente.Strassenelemente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Builder
{
    public class StrasseBuilder
    {
        private readonly Strasse _strasse;

        public StrasseBuilder(Strasse strasse)
        {
            _strasse = strasse;
        }

        public StrasseBuilder AddGerade(string name)
        {
            var gerade = new Gerade(name);
            _strasse.AddStrassenelement(gerade);
            return this;
        }

        public StrasseBuilder AddKurve(string name)
        {
            var kurve = new Kurve(name);
            _strasse.AddStrassenelement(kurve);
            return this;
        }

        // Fügt eine bidirektionale Verbindung zu einer Kreuzung oder einem anderen StraßennetzElement hinzu
        public StrasseBuilder AddVerbindung(StrassennetzElement element, BaseStrassenelement strassenelement = null)
        {
            if (strassenelement != null)
            {
                VerbindungsManager.AddVerbindung(_strasse.Name, new Verbindung(element, strassenelement));
                VerbindungsManager.AddVerbindung(element.Name, new Verbindung(_strasse, strassenelement));
            }
            else
            {
                VerbindungsManager.AddVerbindung(_strasse.Name, new Verbindung(element));
                VerbindungsManager.AddVerbindung(element.Name, new Verbindung(_strasse));
            }
            return this;
        }
    }


}
