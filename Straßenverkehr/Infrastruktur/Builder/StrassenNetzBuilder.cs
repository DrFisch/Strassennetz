using Straßenverkehr.Infrastruktur.Strassennetzelemente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Infrastruktur.Builder
{
    public class StrassenNetzBuilder
    {
        private readonly StrassenNetz _strassennetz;
        private readonly Dictionary<string, Strasse> _strassen = new Dictionary<string, Strasse>(); // Sammlung für gespeicherte Straßen
        private readonly Dictionary<string, Parkplatz> _parkplaetze = new Dictionary<string, Parkplatz>(); // Sammlung für gespeicherte Parkplätze

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
            _parkplaetze[name] = parkplatz;  // Parkplatz speichern
            _strassennetz.AddElement(parkplatz);
            return this;
        }

        // Fügt eine Straße zum Netz hinzu
        public StrassenNetzBuilder AddStrasse(string name, Action<StrasseBuilder> buildStrasse)
        {
            var strasse = new Strasse(name);
            var strasseBuilder = new StrasseBuilder(strasse);
            buildStrasse(strasseBuilder);
            _strassen[name] = strasse;  // Speichere die Straße
            _strassennetz.AddElement(strasse);
            return this;
        }

        // Methode, um eine Straße während des Bauens abzurufen
        public Strasse GetStrasse(string name)
        {
            if (_strassen.ContainsKey(name))
            {
                return _strassen[name];
            }
            throw new Exception($"Strasse {name} nicht gefunden.");
        }

        // Methode, um einen Parkplatz während des Bauens abzurufen
        public Parkplatz GetParkplatz(string name)
        {
            if (_parkplaetze.ContainsKey(name))
            {
                return _parkplaetze[name];
            }
            throw new Exception($"Parkplatz {name} nicht gefunden.");
        }

        // Baut das fertige Strassennetz
        public StrassenNetz Build()
        {
            return _strassennetz;
        }
    }

}

