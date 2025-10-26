using System;
using List.Class;

namespace ListConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            int option;

            do
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("Ingrese una opción: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Dato a insertar: ");
                        list.AddOrdered(Console.ReadLine());
                        break;
                    case 2:
                        list.DisplayForward();
                        break;
                    case 3:
                        list.DisplayBackward();
                        break;
                    case 4:
                        list.SortDescending();
                        Console.WriteLine("Lista ordenada descendentemente.");
                        break;
                    case 5:
                        list.Moda();
                        break;
                    case 6:
                        list.ShowGraph();
                        break;
                    case 7:
                        Console.Write("Ingrese dato a buscar: ");
                        Console.WriteLine(list.Exists(Console.ReadLine()) ? "Existe" : "No existe");
                        break;
                    case 8:
                        Console.Write("Dato a eliminar una vez: ");
                        list.RemoveOne(Console.ReadLine());
                        break;
                    case 9:
                        Console.Write("Dato a eliminar todas las veces: ");
                        list.RemoveAll(Console.ReadLine());
                        break;
                }
            } while (option != 0);
        }
    }
}
