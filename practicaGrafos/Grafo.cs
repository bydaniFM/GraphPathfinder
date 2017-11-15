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
            Arista<Informacion> n = new Arista<Informacion>(v1, v2);
            if (aristas.Pertenece(n))
                aristas.Borrar(n);
        }

        // Solo se considera el borrado de vértices, no el de las aristas adyacentes
        public void BorrarVertice(Informacion vertice) {
            if (vertices.Pertenece(vertice))
                vertices.Borrar(vertice);
        }

        // Este método debe calcular el camino “más corto” (de menor coste teniendo en cuenta los pesos de
        // la aristas) entre el nodo origen y el nodo destino. Devuelve un elemento de tipo List de C# con los
        // nodos que hay que recorrer para llegar del origen al destino por el camino “más corto”. En caso de
        // que en el grafo no hay un camino definido entre el origen y el destino debe devolver null.
        public List<Informacion> CaminoMasCorto(Informacion origen, Informacion destino) {
            int nv = vertices.GetNumeroVertices();
            int na = aristas.GetNumeroAristas();
            int ori = 0;
            int des = 0;
            double[,] adyacencias = new double[nv, nv];
            double[,] predecesores = new double[nv, nv];
            Informacion[] infVertices = vertices.ObtenerVertices();
            Arista<Informacion>[] infAristas = aristas.ObtenerAristas();
            List<Informacion> recorrido = new List<Informacion>();
            int nOrigen = -1;
            int nDestino = -1;
            int encontrado = 0;

            // Bucle para inicializar la matriz de adyacencias y predecesores
            for (int i = 0; i < nv; i++) {
                for (int j = 0; j < nv; j++) {
                    if (i == j) {
                        adyacencias[i, j] = 0;
                        predecesores[i, j] = 0;
                    } else {
                        adyacencias[i, j] = double.PositiveInfinity;
                        predecesores[i, j] = i;
                    }
                }
            }

            // Bucle para incluir los valores de las aristas en la matriz de adyacencias
            for (int i = 0; i < na; i++) {
                for (int j = 0; j < nv; j++) {
                    if (infAristas[i].Origen.Equals(infVertices[j]))
                        ori = j;
                    if (infAristas[i].Destino.Equals(infVertices[j]))
                        des = j;
                }
                adyacencias[ori, des] = infAristas[i].Peso;
            }
            //Algoritmo de Floyd-Warshall
            for (int k = 0; k < nv; k++) {
                for (int i = 0; i < nv; i++) {
                    for (int j = 0; j < nv; j++) {
                        if (adyacencias[i, j] > adyacencias[i, k] + adyacencias[k, j]) {
                            adyacencias[i, j] = adyacencias[i, k] + adyacencias[k, j];
                            predecesores[i, j] = predecesores[k, j];
                        }
                    }
                }
            }

            // Se asignan a las variables nOrigen y nDestino la posición del origen y del destino en el array de vertices
            for (int i = 0; i < infVertices.Length && encontrado <= 2; i++) {
                if (origen.Equals(infVertices[i])) {
                    nOrigen = i;
                    encontrado++;
                }
                if (destino.Equals(infVertices[i])) {
                    nDestino = i;
                    encontrado++;
                }
            }
            // Se comprueba si existe la ruta entre los nodos, en caso de que exista, se obtiene la ruta a traves de la matriz de predecesores
            if (adyacencias[nOrigen, nDestino] == double.PositiveInfinity) {
                recorrido = null;
            } else {
                recorrido.Add(destino);
                while (nOrigen != nDestino) {
                    nDestino = Convert.ToInt32(predecesores[nOrigen, nDestino]);
                    recorrido.Add(infVertices[nDestino]);
                }
                recorrido.Reverse();
            }
            return recorrido;
        }
        
        // Metodo para probar que las matrices del algoritmo se construyen correctamente
        public void pintarMatriz (double[,] adyacencias) {
            int nv = adyacencias.GetLength(0);
            Console.WriteLine();
            for (int i = 0; i < nv; i++) {
                for (int j = 0; j < nv; j++) {
                    if (adyacencias[i, j] == double.PositiveInfinity)
                        Console.Write(" -");
                    else
                        Console.Write(" " + adyacencias[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Devuelve el conjunto de aristas del grafo.
        public CjtA<Informacion> GetAristas() {
            return this.aristas;
        }

        // Devuelve el conjunto de vertices del grafo.
        public CjtV<Informacion> GetVertices() {
            return this.vertices;
        }

        // Construye un grafo inicialmente vacío, sin aristas ni nodos.
        public Grafo() {
            this.aristas = new CjtA<Informacion>();
            this.vertices = new CjtV<Informacion>();
        }

        // Inserta una nueva arista(con peso 0) en el conjunto de aristas del grafo, si esta no estaba
        // previamente en el grafo.Al ser un grafo dirigido hay que tener en cuenta que la arista (v1, v2) es
        // distinta a(v2, v1). Si alguno de los nodos no pertenecía al conjunto de nodos, hay que añadirlo al
        // conjunto de nodos.
        public void InsertarArista(Informacion v1, Informacion v2) {
            Arista<Informacion> n = new Arista<Informacion>(v1, v2);
            if (!aristas.Pertenece(n)) {
                if (!vertices.Pertenece(v1))
                    vertices.Insertar(v1);
                if (!vertices.Pertenece(v2))
                    vertices.Insertar(v2);
                aristas.Insertar(n);
            }
        }

        // Inserta una nueva arista ponderada en el conjunto de aristas del grafo, si esta no estaba previamente
        // en el grafo.Al ser un grafo dirigido hay que tener en cuenta que la arista(v1, v2, px) es distinta a
        // (v2, v1, py). No puede existir más de una arista en el mismo sentido entre dos nodos.Si alguno de
        // los nodos no pertenecía al conjunto de nodos, hay que añadirlo al conjunto de nodos.
        public void InsertarArista(Informacion v1, Informacion v2, double peso) {
            Arista<Informacion> n = new Arista<Informacion>(v1, v2, peso);
            if (!aristas.Pertenece(n)) {
                if (!vertices.Pertenece(v1))
                    vertices.Insertar(v1);
                if (!vertices.Pertenece(v2))
                    vertices.Insertar(v2);
                aristas.Insertar(n);
            }
        }

        public void InsertarVertice(Informacion vertice) {
            if (!vertices.Pertenece(vertice))
                vertices.Insertar(vertice);
        }

        public override string ToString() {
            string cadenaGrafo = "";
            cadenaGrafo = string.Concat(vertices.ToString(), "\n", aristas.ToString());
            return cadenaGrafo;
        }
    }
}
