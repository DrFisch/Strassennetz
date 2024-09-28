using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract
{
    public abstract class BaseStrassenelement
    {
        public string Name { get; set; }
        public double Laenge { get; set; }  // Länge des Straßenelements in Metern

        protected BaseStrassenelement(string name, double laenge)
        {
            Name = name;
            Laenge = laenge;
        }

        public abstract void Anzeigen();
    }
}
