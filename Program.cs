using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;
using System.Collections.Generic;

namespace ATMStartBank;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Usuario? Usuario = Usuario.CrearUsuario(); //GENERA UN USUARIO SEGUN SU ID
            Atm? Atm = Atm.EfectivoInicio(); //Trae el efectivo del banco
            

            bool salir = false;
            while (!salir)
            {

                Interfaz.MostrarHeader(); // HEADER
                Console.WriteLine($"\nBienvenido {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
                
                Console.WriteLine("\t🌟 Menú Principal 🌟\n");
                Console.WriteLine("1. 💰 Depositar a tu cuenta");
                Console.WriteLine("2. 💳 Pagar (Servicios, Tarjetas, Créditos y más)");
                Console.WriteLine("3. 💸 Retirar (Efectivo y operaciones con tarjeta)");
                Console.WriteLine("4. ❌ Salir");

                Console.Write("\nPor favor, ingresa el número de la opción que deseas realizar. \n--> ");
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Depositos.RealizarDeposito(Usuario, Atm);
                        break;
                    case "2":
                        Pagos.MenuPagos(Usuario, Atm);
                        break;
                    case "3":
                        Retirar.IngresarIRetiro(Usuario, Atm);
                        break;
                    case "4":
                        Console.WriteLine("\n✅ Vuelva pronto...");
                        Console.WriteLine("💳 Retire su tarjeta.");
                        Thread.Sleep(5000);
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\n⚠️  Por favor, selecciona una opción válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }

            }
        }
    }

}