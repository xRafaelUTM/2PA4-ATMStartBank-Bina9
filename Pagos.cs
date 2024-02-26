using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;
using System.Collections.Generic;

namespace ATMStartBank;
public class Pagos
{
    public static void MenuPagos(Usuario? Usuario)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Dictionary<int, Tuple<string, string>> servicios = new Dictionary<int, Tuple<string, string>>()
        {
            { 1, Tuple.Create("de tarjeta de crédito 💳", "saldoTarjetaCredito") },
            { 2, Tuple.Create("hipotecario 🏠", "pagoHipotecario") },
            { 3, Tuple.Create("de carro 🚗", "pagoCarro") },
            { 4, Tuple.Create("de servicio CFE 💡", "pagoCFE") },
            { 5, Tuple.Create("de servicio Telmex 📞", "pagoTelmex") },
            { 6, Tuple.Create("de servicio Japay 💦", "pagoJapay") },
            { 7, Tuple.Create("de servicio Telcel 📱", "pagoTelcel") },
            { 8, Tuple.Create("de servicio TotalPlay 📺", "pagoTotalPlay") },
            { 9, Tuple.Create("de colegiatura 📚", "pagoColegiatura") }
        };
    

        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");

        Console.WriteLine("\t🌟 Menú de Pagos 🌟\n");
        Console.WriteLine("1. 💳 Saldo Tarjeta de Crédito");
        Console.WriteLine("2. 🏠 Pago Hipotecario");
        Console.WriteLine("3. 🚗 Pago Carro");
        Console.WriteLine("4. 💡 Pago CFE");
        Console.WriteLine("5. 📞 Pago Telmex");
        Console.WriteLine("6. 💦 Pago Japay");
        Console.WriteLine("7. 📱 Pago Telcel");
        Console.WriteLine("8. 📺 Pago TotalPlay");
        Console.WriteLine("9. 📚 Pago Colegiatura");
        Console.WriteLine("10.❌ Cancelar la operación.");

        int opcion = 10;
        Console.Write("\nPor favor ingresa el número de la opción que deseas realizar \n--> ");

        do
        {
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion > 10 || opcion < 1)
                {
                    Console.Write("🚫 Ingresa un servicio existente --> ");
                } 
                else if (opcion == 10)
                {
                    Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                    return; // Salir hacia el main 
                }
                else{break;}
            }
            catch (Exception)
            {
                Console.Write("🚫 Ingresa un valor valido --> ");
            }
        } while (true);

        RealizarPago(Usuario, servicios, opcion);
        
    }

    public static void RealizarPago(Usuario? Usuario,Dictionary<int, Tuple<string, string>> servicios, int opcion)
    {
        Tuple<string, string> valor = servicios[opcion];
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n\t🌟Pago {valor.Item1}\n");
        Console.ReadKey();



    }
}