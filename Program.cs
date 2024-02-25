using System.Text;
using System.Data.SqlClient;

namespace ATMStartBank;

class Program
{
    static void Main(string[] args)
    {
        // Establece la codificación UTF-8 como la codificación predeterminada para todas las operaciones de entrada y salida
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            Usuario? Usuario = Usuario.CrearUsuario();
            Console.Clear();

            bool salir = false;
            while (!salir)
            {
                Console.Clear(); // Limpiar la consola en cada iteración

                Interfaz.mostrarHeader();
                Console.WriteLine($"\nBienvenido {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
                
                Console.WriteLine("\t🌟 Menú Principal 🌟\n");
                Console.WriteLine("1. 💰 Depositar a tu cuenta");
                Console.WriteLine("2. 💳 Pagar (Servicios, Tarjetas, Créditos y más)");
                Console.WriteLine("3. 💸 Retirar (Efectivo y operaciones con tarjeta)");
                Console.WriteLine("4. ❌ Salir");

                Console.Write("\nPor favor ingresa el número de la opción que deseas realizar. \n--> ");
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n🏦 Has seleccionado: Depositar a tu cuenta");
                        // Lógica para depositar
                        break;
                    case "2":
                        Console.WriteLine("\n💳 Has seleccionado: Pagar");
                        // Lógica para pagar
                        break;
                    case "3":
                        Console.WriteLine("\n💸 Has seleccionado: Retirar");
                        // Lógica para retirar
                        break;
                    case "4":
                        Console.WriteLine("\n❌ Saliendo del programa...");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\n⚠️  Por favor selecciona una opción válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }

            }
            if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                } 
        }
    }
}