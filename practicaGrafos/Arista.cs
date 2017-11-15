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
            this.origen = origen;
            this.destino = destino;
        }

        // Construye una arista con origen, destino y peso
        public Arista(Informacion origen, Informacion destino, double peso) {
            this.origen = origen;
            this.destino = destino;
            this.peso = peso;
        }

        //Este método devuelve true si obj es igual a la arista actual, esto es, si coindicen su origen, su destino y su peso.En otro caso devuelve false.
        public bool Equals(Arista<Informacion> obj) {
            if (obj.Origen.ToString() == this.origen.ToString() && obj.Destino.ToString() == this.destino.ToString() && obj.Peso.ToString() == this.peso.ToString())
                return true;
            else
                return false;
        }

        // Devuelve una cadena de texto con el contenido del conjunto de vértices de la forma (origen, destino, peso).
        public override string ToString() {
            return this.origen + ", " + this.destino + ", " + this.peso;
        }
    }
}
