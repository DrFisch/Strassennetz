using Straßenverkehr.Infrastruktur.Helper;
using Straßenverkehr.Infrastruktur.Strassennetzelemente;
using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;
using Straßenverkehr.Infrastruktur.Strassennetzelemente.Strassenelemente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Infrastruktur.Builder
{
    public class StrasseBuilder
    {
        private readonly Strasse _strasse;

        public StrasseBuilder(Strasse strasse)
        {
            _strasse = strasse;
        }

        public StrasseBuilder AddGerade(string name, double laenge)
        {
            var gerade = new Gerade(name, laenge);
            _strasse.AddStrassenelement(gerade);
            return this;
        }

        public StrasseBuilder AddKurve(string name, double laenge)
        {
            var kurve = new Kurve(name, laenge);
            _strasse.AddStrassenelement(kurve);
            return this;
        }
    }
}
