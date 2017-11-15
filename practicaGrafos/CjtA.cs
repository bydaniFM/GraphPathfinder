using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaGrafos {
    class CjtA<Informacion> {

        private Nodo<Arista<Informacion>> conjunto;

        // Este método elimina la arista e del conjunto de vértices. En caso de no pertenecer al conjunto no hace nada.
        // Se comprueba si pertenece en la clase grafo
        public void Borrar(Arista<Informacion> e) {
            Nodo<Arista<Informacion>> recorrido = conjunto;
            Nodo<Arista<Informacion>> previo = conjunto;
            int pos = 1;
            while (!(recorrido.darDato().Origen.Equals(e.Origen) && recorrido.darDato().Destino.Equals(e.Destino))) {
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

        // Construye un conjunto de aristas inicialmente vacío.
        public CjtA() {
            conjunto = null;
        }

        // Constructor de copia. Crea un conjunto nuevo de aristas con todos los elementos del otroConjunto.
        public CjtA(CjtA<Informacion> otroConjunto) {
            conjunto = otroConjunto.conjunto;
        }

        // Este método devuelve true si el conjunto no almacena ninguna arista, false en otro caso.
        public bool EsVacio() {
            if (conjunto == null)
                return true;
            else
                return false;
        }

        // Devuelve el número de aristas que hay en el conjunto. Si el conjunto está vacío devuelve 0.
        public int GetNumeroAristas() {
            Nodo<Arista<Informacion>> recorrido = conjunto;
            int contador = 0;
            while (recorrido != null) {
                contador++;
                recorrido = recorrido.darSiguiente();
            }
            return contador;
        }

        // Añade la arista e al conjunto de aristas si no estaba previamente almacenada.
        public void Insertar(Arista<Informacion> e) {
            Nodo<Arista<Informacion>> n = new Nodo<Arista<Informacion>>(e, conjunto);
            this.conjunto = n;
        }

        // Este método devuelve un array con las aristas almacenadas en el conjunto de aristas.
        public Arista<Informacion>[] ObtenerAristas() {
            Nodo<Arista<Informacion>> recorrido = conjunto;
            int na = this.GetNumeroAristas();
            Arista<Informacion>[] array = new Arista<Informacion>[na];
            for (int i = 0; i < na; i++) {
                array[i] = recorrido.darDato();
                recorrido = recorrido.darSiguiente();
            }
            return array;
        }

        // Devuelve true si e está almacenado en el conjunto de aristas, false en otro caso.
        public bool Pertenece(Arista<Informacion> e) {
            Nodo<Arista<Informacion>> recorrido = conjunto;
            bool pertenece = false;
            while (recorrido != null && !pertenece) {
                if (recorrido.darDato().Origen.Equals(e.Origen) && recorrido.darDato().Destino.Equals(e.Destino)) { //recorrido.darDato().Equals(e)
                    pertenece = true;
                } else {
                    recorrido = recorrido.darSiguiente();
                }
            }
            return pertenece;
        }

        // Devuelve una cadena de texto con el contenido del conjunto de vértices de la forma {(o1,d1,p1), (o2,d2,p2), …, (on,dn,pn)}.
        public override string ToString() {
            Nodo<Arista<Informacion>> recorrido = conjunto;
            string cadenaAristas = "Aristas: {";
            int na = this.GetNumeroAristas();
            for (int i = 0; i < na; i++) {
                if (i != na - 1)
                    cadenaAristas = string.Concat(cadenaAristas, "(", recorrido.darDato(), ")", ", ");
                else
                    cadenaAristas = string.Concat(cadenaAristas, "(", recorrido.darDato(), ")");
                recorrido = recorrido.darSiguiente();
            }
            cadenaAristas = string.Concat(cadenaAristas, "}");
            return cadenaAristas;
        }
    }
}
