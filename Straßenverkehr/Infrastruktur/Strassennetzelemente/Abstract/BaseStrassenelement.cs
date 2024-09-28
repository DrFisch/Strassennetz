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

        protected BaseStrassenelement(string name)
        {
            Name = name;
        }

        public abstract void Anzeigen();
    }
}
