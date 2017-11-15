using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaGrafos {
    class Grafo<Informacion> {

        private CjtA<Informacion> aristas;
        private CjtV<Informacion> vertices;

        // Este método elimina la arista del conjunto de aristas, mientras que los vértices permanecen en el
        // conjunto de veritces.En caso de no pertenece al conjunto no hace nada.
        public void BorrarArista(Informacion v1, Informacion v2) {

        }

        // Este método debe calcular el camino “más corto” (de menor coste teniendo en cuenta los pesos de
        // la aristas) entre el nodo origen y el nodo destino.Devuelve un elemento de tipo List de C# con los
        // nodos que hay que recorrer para llegar del origen al destino por el camino “más corto”. En caso de
        // que en el grafo no hay un camino definido entre el origen y el destino debe devolver null.
        public List<Informacion> CaminoMasCorto(Informacion origen, Informacion destino) {
            throw new NotImplementedException();
        }

        // Devuelve el conjunto de aristas del grafo.
        public CjtA<Informacion> GetAristas() {
            throw new NotImplementedException();
        }

        // Devuelve el conjunto de vertices del grafo.
        public CjtV<Informacion> GetVertices() {
            throw new NotImplementedException();
        }

        // Construye un grafo inicialmente vacío, sin aristas ni nodos.
        public Grafo() {

        }

        // Inserta una nueva arista(con peso 0) en el conjunto de aristas del grafo, si esta no estaba
        // previamente en el grafo.Al ser un grafo dirigido hay que tener en cuenta que la arista (v1, v2) es
        // distinta a(v2, v1). Si alguno de los nodos no pertenecía al conjunto de nodos, hay que añadirlo al
        // conjunto de nodos.
        public void InsertarArista(Informacion v1, Informacion v2) {

        }

        // Inserta una nueva arista ponderada en el conjunto de aristas del grafo, si esta no estaba previamente
        // en el grafo.Al ser un grafo dirigido hay que tener en cuenta que la arista(v1, v2, px) es distinta a
        // (v2, v1, py). No puede existir más de una arista en el mismo sentido entre dos nodos.Si alguno de
        // los nodos no pertenecía al conjunto de nodos, hay que añadirlo al conjunto de nodos.
        public void InsertarArista(Informacion v1, Informacion v2, double peso) {

        }
    }
}
