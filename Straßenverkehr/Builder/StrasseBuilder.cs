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

        // Fügt eine Verbindung (z. B. zu einem Parkplatz oder einer Kreuzung) hinzu
        public StrasseBuilder AddVerbindung(StrassennetzElement element)
        {
            _strasse.AddVerbindung(element);
            return this;
        }
    }

}
