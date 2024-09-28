using Straßenverkehr.Strassennetzelemente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Builder
{
    public class StrassenNetzBuilder
    {
        private readonly StrassenNetz _strassennetz;

        public StrassenNetzBuilder()
        {
            _strassennetz = new StrassenNetz();
        }

        // Fügt eine Kreuzung zum Netz hinzu
        public StrassenNetzBuilder AddKreuzung(string name, Action<Kreuzung> configure = null)
        {
            var kreuzung = new Kreuzung(name);
            configure?.Invoke(kreuzung);
            _strassennetz.AddElement(kreuzung);
            return this;
        }

        // Fügt einen Parkplatz zum Netz hinzu
        public StrassenNetzBuilder AddParkplatz(string name, Action<Parkplatz> configure = null)
        {
            var parkplatz = new Parkplatz(name);
            configure?.Invoke(parkplatz);
            _strassennetz.AddElement(parkplatz);
            return this;
        }

        // Fügt eine Strasse zum Netz hinzu
        public StrassenNetzBuilder AddStrasse(string name, Action<StrasseBuilder> buildStrasse)
        {
            var strasse = new Strasse(name);
            var strasseBuilder = new StrasseBuilder(strasse);
            buildStrasse(strasseBuilder);
            _strassennetz.AddElement(strasse);
            return this;
        }

        // Baut das fertige Strassennetz
        public StrassenNetz Build()
        {
            return _strassennetz;
        }
    }
}

