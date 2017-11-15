using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaGrafos {
    class Arista<Informacion> {

        private Informacion destino;
        private Informacion origen;
        private double peso;

        public Informacion Destino {
            get {
                return destino;
            }
        }
        public Informacion Origen {
            get {
                return origen;
            }
        }
        public double Peso {
            get {
                return peso;
            }
        }

        // Construye una arista con origen y destino. El peso es 0.
        public Arista(Informacion origen, Informacion destino) {

        }

        // Construye una arista con origen, destino y peso
        public Arista(Informacion origen, Informacion destino, double peso) {

        }

        //Este método devuelve true si obj es igual a la arista actual, esto es, si coindicen su origen, su destino y su peso.En otro caso devuelve false.
        public bool Equals(object obj) {
            throw new NotImplementedException();
        }

        // Devuelve una cadena de texto con el contenido del conjunto de vértices de la forma (origen, destino, peso).
        public string ToString() {
            throw new NotImplementedException();
        }
    }
}
