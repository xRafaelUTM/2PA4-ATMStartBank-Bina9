using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;

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

                Console.Write("\nPor favor ingresa el número de la opción que deseas realizar. \n--> ");
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Deposito(Usuario);
                        break;
                    case "2":
                        Console.WriteLine("\n💳 Has seleccionado: Pagar");
                        //Lógica para pagar
                        break;
                    case "3":
                        Console.WriteLine("\n💸 Has seleccionado: Retirar");
                        //Lógica para retirar
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


    public static void Deposito(Usuario? Usuario)
    {
        Interfaz.MostrarHeader(); // HEADER
        Interfaz.DatosDepositoTarjeta(Usuario);
        
        decimal importe;
        while (true)
        {
            Console.Write("💲 Ingrese el importe a depositar. [Si desea cancelar, ingrese: * ]\n--> ");
            string? input = Console.ReadLine();

            if (input == "*")
            {
                Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                return; //Salir hacia el main
            }
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (Validaciones.TryObtenerImporte(input, out importe) && Validaciones.ValidarImporte(importe))
                {
                    
                    Interfaz.MostrarHeader(); // HEADER
                    Interfaz.DatosDepositoTarjetaImporte(Usuario, importe);
                    
                    Console.Write("❕ Ingrese el motivo de pago. [Si desea cancelar, ingrese: * ]\n--> ");
                    input = Console.ReadLine();
                    string? motivo = input;
                    if (input == "*")
                    {
                        Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                        return;
                    }
                    else
                    {
                        Interfaz.MostrarHeader(); // HEADER
                        Console.WriteLine("\n\t🌟 DATOS DEL DEPÓSITO 🌟\n");
                        Console.WriteLine($"💳 Tarjeta: \t{Usuario?.tarjetaDebito}\n");
                        Console.WriteLine($"💰 Importe: \t{importe:C}\n");
                        Console.WriteLine($"📝 Motivo: \t{input}\n");
                        
                        Console.Write("❕ ¿Todos los datos son correctos?. \n\n1.[✅ Continuar] // 2.[❌ Cancelar operación]\n--> ");
                        
                        do
                        {
                            input = Console.ReadLine();

                            if (input == "2"){Console.WriteLine("\n🚫 El usuario ha cancelado la operación."); return;}
                            else if(input == "1")
                            {
                                Usuario?.DepositoUpdate(Usuario,importe);
                                Comprobante.ComprobanteDepositos(Usuario,importe, motivo);
                                Interfaz.MostrarHeader(); // HEADER
                                Console.WriteLine("\n✅ Depósito exitoso.");
                                Console.WriteLine("\n📃 SE HA IMPRESO SU COMPROBANTE 📃");
                                break;
                            }
                            else
                            {
                                Console.Write("🚫 Seleccione un dato correcto.\n--> ");
                            }
                            
                        } while (true);

                        break;
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("⚠️ Por favor, ingrese un importe válido.");
            }

        }
    }
}