using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract
{
    public abstract class StrassennetzElement
    {
        public string Name { get; set; }

        protected StrassennetzElement(string name)
        {
            Name = name;
        }

        public abstract void Anzeigen();
    }
}
