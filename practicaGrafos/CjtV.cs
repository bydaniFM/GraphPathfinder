using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaGrafos {
    class CjtV<Informacion> {

        private Nodo<Informacion> conjunto;

        // Este método elimina el elemento e del conjunto de vértices. En caso de no pertenece al conjunto no hace nada.
        public void Borrar(Informacion e) {

        }

        // Construye un conjunto de vértices inicialmente vacío.
        public CjtV() {
            Informacion e = default(Informacion);
            conjunto = new Nodo<Informacion>(e);
        }

        // Constructor de copia.Crea un conjunto nuevo de vértices con todos los elementos del otroConjunto.
        public CjtV(CjtV<Informacion> otroConjunto) {
            conjunto = otroConjunto.conjunto;
        }

        // Este método devuelve true si el conjunto no almacena ningún vértice, false en otro caso.
        public bool EsVacio() {
            if (conjunto == null)
                return true;
            else
                return false;
        }

        //Devuelve el número de vértices que hay en el conjunto. Si el conjunto está vacío devuelve 0.
        public int GetNumeroVertices() {
            int contador = 0;

            while (conjunto != null) {
                contador++;
                conjunto = conjunto.darSiguiente();
            }

            return contador;
        }

        // Añade el elemento e al conjunto de vértices si no estaba previamente almacenado.
        public void Insertar(Informacion e) {
            while (conjunto != null && conjunto.darDato() != e) {
                conjunto = conjunto.darSiguiente();
            }
            conjunto.fijarSiguiente(e);
        }

        // Este método devuelve un array con los valores almacenados en el conjunto de vértices.
        public Informacion[] ObtenerVertices() {
            throw new NotImplementedException();
        }

        // Devuelve true si e está almacenado en el conjunto de vértices, false en otro caso.
        public bool Pertenece(Informacion e) {
            throw new NotImplementedException();
        }

        // Devuelve una cadena de texto con el contenido del conjunto de vértices de la forma {v1, v2, …, vn}.
        public string ToString() {
            throw new NotImplementedException();
        }
    }
}
