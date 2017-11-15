using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaGrafos {
    class CjtA<Informacion> {

        private Nodo<Arista<Informacion>> conjunto;

        // Este método elimina la arista e del conjunto de vértices. En caso de no pertenece al conjunto no hace nada.
        public void Borrar(Arista<Informacion> e) {

        }

        // Construye un conjunto de aristas inicialmente vacío.
        public CjtA() {

        }

        // Constructor de copia. Crea un conjunto nuevo de vértices con todos los elementos del otroConjunto.
        public CjtV(CjtV<Informacion> otroConjunto) {

        }

        // Este método devuelve true si el conjunto no almacena ninguna arista, false en otro caso.
        public bool EsVacio() {
            throw new NotImplementedException();
        }

        // Devuelve el número de aristas que hay en el conjunto. Si el conjunto está vacío devuelve 0.
        public int GetNumeroAristas() {
            throw new NotImplementedException();
        }

        // Añade la arista e al conjunto de aristas si no estaba previamente almacenada.
        public void Insertar(Arista<Informacion> e) {

        }

        // Este método devuelve un array con las aristas almacenadas en el conjunto de aristas.
        public Arista<Informacion>[] ObtenerAristas() {
            throw new NotImplementedException();
        }

        // Devuelve true si e está almacenado en el conjunto de aristas, false en otro caso.
        public bool Pertenece(Arista<Informacion> e) {
            throw new NotImplementedException();
        }

        // Devuelve una cadena de texto con el contenido del conjunto de vértices de la forma {(o1,d1,p1), (o2,d2,p2), …, (on,dn,pn)}.
        public string ToString() {
            throw new NotImplementedException();
        }
    }
}
