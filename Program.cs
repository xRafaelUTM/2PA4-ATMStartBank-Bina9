using System.Text;

namespace ATMStartBank;

class Program
{
    public static int contador;
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            contador = 0;
            Console.Clear();
            Usuario? Usuario = Usuario.CrearUsuario(); //GENERA UN USUARIO SEGUN SU ID
            Atm? Atm = Atm.EfectivoInicio(); //Trae el efectivo del banco
            

            bool salir = false;
            while (!salir)
            {
                if (Program.contador == 5)
                {
                    Interfaz.MostrarHeader(); // HEADER
                    Console.WriteLine($"\n{Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
                    Console.WriteLine("\t🌟 Ha alcanzado el maximo de movimientos... [ENTER] 🌟\n");
                    Console.ReadKey();
                    break;
                    
                }
                else
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

}