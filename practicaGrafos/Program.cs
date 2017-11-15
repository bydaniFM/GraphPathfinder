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
            int opc = 0;
            bool continuar = false;
            string string1 = "";
            string string2 = "";
            int peso = 0;
            Grafo<string> grafo = new Grafo<string>();

            grafo.InsertarArista("Anoth", "Arkania", 7);
            grafo.InsertarArista("Anoth", "Drall", 3);
            grafo.InsertarArista("Arkania", "Drall", 1);
            grafo.InsertarArista("Arkania", "Bespin", 6);
            grafo.InsertarArista("Drall", "Cerea", 8);
            grafo.InsertarArista("Bespin", "Drall", 3);
            grafo.InsertarArista("Bespin", "Chandrila", 2);
            grafo.InsertarArista("Cerea", "Chandrila", 8);
            grafo.InsertarArista("Cerea", "Bespin", 2);
            
            do {
                Console.Clear();
                Console.WriteLine("Elija una operación:");
                Console.WriteLine();
                Console.WriteLine("1 - Calcular camino mas corto entre dos nodos");
                Console.WriteLine("2 - Introducir nodo");
                Console.WriteLine("3 - Eliminar nodo");
                Console.WriteLine("4 - Introducir Arista");
                Console.WriteLine("5 - Borrar Arista");
                Console.WriteLine("6 - Ver todos los nodos y aristas");
                Console.WriteLine("7 - Salir");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc) {
                    case 1:
                        do {
                            Console.WriteLine("Introduce el nodo de origen: ");
                            string1 = Console.ReadLine();
                            Console.WriteLine("Introduce el nodo de destino: ");
                            string2 = Console.ReadLine();
                            if (grafo.GetVertices().Pertenece(string1) && grafo.GetVertices().Pertenece(string2))
                                continuar = true;
                            else
                                Console.WriteLine("El nodo introducido no se encuentra en el grafo");
                        } while (!continuar);
                        Console.WriteLine(imprimirLista(grafo.CaminoMasCorto(string1, string2)));
                        Console.WriteLine("Pulse ENTER para continuar");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Introduce el nodo a insertar: ");
                        string1 = Console.ReadLine();
                        grafo.InsertarVertice(string1);
                        break;
                    case 3:
                        Console.WriteLine("Introduce el nodo a borrar: ");
                        string1 = Console.ReadLine();
                        grafo.BorrarVertice(string1);
                        break;
                    case 4:
                        Console.WriteLine("Introduce el nodo de origen: ");
                        string1 = Console.ReadLine();
                        Console.WriteLine("Introduce el nodo de destino: ");
                        string2 = Console.ReadLine();
                        Console.WriteLine("Introduce el peso");
                        peso = Convert.ToInt32(Console.ReadLine());
                        grafo.InsertarArista(string1, string2, peso);
                        break;
                    case 5:
                        Console.WriteLine("Introduce el nodo de origen: ");
                        string1 = Console.ReadLine();
                        Console.WriteLine("Introduce el nodo de destino: ");
                        string2 = Console.ReadLine();
                        grafo.BorrarArista(string1, string2);
                        break;
                    case 6:
                        Console.WriteLine(grafo.ToString());
                        Console.WriteLine("Pulse ENTER para continuar");
                        Console.ReadLine();
                        break;
                }
            } while (opc != 7);
        }

        public static string imprimirLista(List<String> list) {
            string x = "Ruta mas corta: ";

            if (list == null) {
                return x = "No se ha encontrado ruta";
            } else {
                for (int i = 0; i < list.Count; i++) {
                    if (i != list.Count - 1)
                        x += list[i] + " -> ";
                    else
                        x += list[i];
                }
                return x;
            }
        }
    }
}
