using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaGrafos {
    class CjtV<Informacion> {

        private Nodo<Informacion> conjunto;

        // Este método elimina el elemento e del conjunto de vértices. En caso de no pertenecer al conjunto no hace nada.
        // Se comprueba si pertenece en la clase grafo
        public void Borrar(Informacion e) {
            Nodo<Informacion> recorrido = conjunto;
            Nodo<Informacion> previo = conjunto;
            int pos = 1;
            
            while (!recorrido.darDato().Equals(e)) {
                recorrido = recorrido.darSiguiente();
                if (pos != 1)
                    previo = previo.darSiguiente();
                pos++;
            }
            if (pos == 1) {
                 conjunto = conjunto.darSiguiente();
            } else {
                previo.fijarSiguiente(recorrido.darSiguiente());
            }
        }

        // Construye un conjunto de vértices inicialmente vacío.
        //FUNCIONA
        public CjtV() {
            this.conjunto = null;
        }

        // Constructor de copia.Crea un conjunto nuevo de vértices con todos los elementos del otroConjunto.
        public CjtV(CjtV<Informacion> otroConjunto) {
            this.conjunto = otroConjunto.conjunto;
        }

        // Este método devuelve true si el conjunto no almacena ningún vértice, false en otro caso.
        //FUNCIONA
        public bool EsVacio() {
            if (conjunto == null)
                return true;
            else
                return false;
        }

        // Devuelve el número de vértices que hay en el conjunto. Si el conjunto está vacío devuelve 0.
        //FUNCIONA
        public int GetNumeroVertices() {
            Nodo<Informacion> recorrido = conjunto;
            int contador = 0;

            while (recorrido != null) {
                contador++;
                recorrido = recorrido.darSiguiente();
            }
            return contador;
        }

        // Añade el elemento e al conjunto de vértices si no estaba previamente almacenado.
        //FUNCIONA
        public void Insertar(Informacion e) {
            if (!this.Pertenece(e)) {
                Nodo<Informacion> n = new Nodo<Informacion>(e, conjunto);
                this.conjunto = n;
            }
        }

        // Este método devuelve un array con los valores almacenados en el conjunto de vértices.
        //FUNCIONA
        public Informacion[] ObtenerVertices() {
            Nodo<Informacion> recorrido = conjunto;
            int nv = this.GetNumeroVertices();
            Informacion[] array = new Informacion[nv];
            for (int i = 0; i < nv; i++) {
                array[i] = recorrido.darDato();
                recorrido = recorrido.darSiguiente();
            }
            return array;
        }

        // Devuelve true si e está almacenado en el conjunto de vértices, false en otro caso.
        //FUNCIONA
        public bool Pertenece(Informacion e) {
            Nodo<Informacion> recorrido = conjunto;
            bool pertenece = false;
            while (recorrido != null && !pertenece) {
                if (recorrido.darDato().Equals(e)) {
                    pertenece = true;
                } else {
                    recorrido = recorrido.darSiguiente();
                }
            }
            return pertenece;
        }

        // Devuelve una cadena de texto con el contenido del conjunto de vértices de la forma {v1, v2, …, vn}.
        //FUNCIONA
        public override string ToString() {
            Nodo<Informacion> recorrido = conjunto;
            string cadenaVertices = "Vertices: {";
            int nv = this.GetNumeroVertices();
            for (int i = 0; i < nv; i++) {
                if (i != nv - 1)
                    cadenaVertices = string.Concat(cadenaVertices, recorrido.darDato() + ", ");
                else
                    cadenaVertices = string.Concat(cadenaVertices, recorrido.darDato());
                recorrido = recorrido.darSiguiente();
            }
            cadenaVertices = string.Concat(cadenaVertices, "}");
            return cadenaVertices;
        }
    }
}
