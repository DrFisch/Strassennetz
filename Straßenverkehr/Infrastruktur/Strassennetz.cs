using Straßenverkehr.Infrastruktur.Strassennetzelemente.Abstract;
using Straßenverkehr.Infrastruktur.Builder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straßenverkehr.Infrastruktur
{
    public class StrassenNetz
    {
        public List<StrassennetzElement> Elemente { get; } = new List<StrassennetzElement>();

        public void AddElement(StrassennetzElement element)
        {
            Elemente.Add(element);
        }

        public void Anzeigen()
        {
            Console.WriteLine("Strassennetz:");
            foreach (var element in Elemente)
            {
                element.Anzeigen();
            }
        }
    }
}
