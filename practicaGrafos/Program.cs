using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaGrafos
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodo<String> Cerea = new Nodo<String>("Cerea", null);
            Nodo<String> Chandrila = new Nodo<String>("Chandrila", Cerea);
            Nodo<String> Bespin = new Nodo<String>("Bespin", Chandrila);
            Nodo<String> Drall = new Nodo<String>("Drall", Bespin);
            Nodo<String> Arkania = new Nodo<String>("Arkania", Drall);
            Nodo<String> Anoth = new Nodo<String>("Anoth", Arkania);

        }
    }
}
