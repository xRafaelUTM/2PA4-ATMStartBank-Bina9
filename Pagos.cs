using System.Text;
using System.Reflection;

namespace ATMStartBank;
public class Pagos
{

    public static void MenuPagos(Usuario? Usuario, Atm? atm)
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
        Console.Write("\nPor favor, ingresa el número de la opción que deseas realizar \n--> ");

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

        VisualizarPago(Usuario, servicios, opcion, atm);
        
    }

    public static void VisualizarPago(Usuario? Usuario, Dictionary<int, Tuple<string, string>> servicios, int opcion, Atm? atm)
    {

        Tuple<string, string> servicioSeleccionado = servicios[opcion];
        string nombrePropiedad = servicioSeleccionado.Item2;

        PropertyInfo? propiedad = typeof(Usuario).GetProperty(nombrePropiedad);
        #pragma warning disable CS8605 // Conversión unboxing a un valor posiblemente NULL.
        decimal valorPago = (decimal)propiedad?.GetValue(Usuario);
        #pragma warning restore CS8605 // Conversión unboxing a un valor posiblemente NULL.
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n🌟 Pago  {servicioSeleccionado.Item1} 🌟\n");
        Console.WriteLine($"\n💸 Importe a pagar: {valorPago}\n");

        if (valorPago == 0)
        {
            Console.WriteLine($"\n\t✔️ USTED NO TIENE ADEUDO ✔️\n");
            return;
        }
        else
        {
            Console.Write("1.[✅ Continuar con el pago] // 2.[❌ Cancelar operación]\n--> ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == "2")
                {
                    Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                    return;
                }
                else if (input == "1")
                {
                    RealizarPago(Usuario, servicios, opcion ,nombrePropiedad, valorPago, atm);
                    break;
                }
                else
                {
                    Console.Write("🚫 Seleccione un dato correcto.\n--> ");
                }
            }

        }
    }
    public static void RealizarPago(Usuario? Usuario, Dictionary<int, Tuple<string, string>> servicios, int opcion, string nombrePropiedad, decimal valorPago, Atm? atm)
    {

        Interfaz.MostrarHeader(); // HEADER
        Tuple<string, string> servicioSeleccionado = servicios[opcion];
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n🌟 Pago:  {servicioSeleccionado.Item1} 🌟\n");
        Console.WriteLine($"\n💸 Importe a pagar: ${valorPago}\n");
        Console.Write("❕ ¿Como desea realizar el pago?. \n\n1.[✅ Efectivo] // 2.[✅ Saldo en cuenta] 3.[❌ Cancelar operación]\n--> ");

        while (true)
        {
            bool salir = true;
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RealizarPagoEfectivo(Usuario, nombrePropiedad, valorPago, servicioSeleccionado, atm);
                    break;

                case "2":
                    if (valorPago > Usuario?.saldoTarjetaDebito)
                    {
                        salir = false;
                        Console.Write("🚫 No tienes saldo suficiente en tu cuenta. \nSelecciona otra opción --> "); 
                        break;
                    }
                    else
                    {
                        RealizarPagoTransaccion(Usuario, nombrePropiedad, valorPago, servicioSeleccionado, atm);
                        break;
                    }

                case "3":
                    Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                    return;

                default:
                    Console.Write("🚫 Seleccione un dato correcto.\n--> ");
                    break;
            }
            if (salir == true)
            {
                if (input == "1" || input == "2"){break;}
            }
            
        }

    }

    public static void RealizarPagoEfectivo(Usuario? Usuario, string nombrePropiedad,decimal importe, Tuple<string, string> servicioSeleccionado, Atm? Atm)
    {
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular: {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n🌟 Pago: {servicioSeleccionado.Item1} 🌟\n");
        Console.WriteLine($"\n💸 Importe a pagar: ${importe}\n");
        Console.Write("❕ Por favor ingrese los billetes. \n\n1.[✅ Listo, continuar] // 2.[❌ Cancelar operación]\n--> ");
        
        while (true)
            {
                string? input = Console.ReadLine();
                if (input == "2")
                {
                    Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                    return;
                }
                else if (input == "1")
                {
                    
                    Usuario?.PagoServicioUpdate(nombrePropiedad, importe);
                    Atm?.EfectivoDepositoUpdate(importe);
                    bool tipo = true;
                    Comprobante.ComprobantePagos(Usuario,importe, servicioSeleccionado, tipo);
                    Interfaz.MostrarHeader(); // HEADER
                    Console.WriteLine("\n✅ Pago exitoso.");
                    Console.WriteLine("\n📃 SE HA IMPRESO SU COMPROBANTE 📃");
                    break;
                }
                else
                {
                    Console.Write("🚫 Seleccione un dato correcto.\n--> ");
                }
            }
        
    }

    public static void RealizarPagoTransaccion(Usuario? Usuario, string nombrePropiedad,decimal importe, Tuple<string, string> servicioSeleccionado, Atm? Atm)
    {
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\nCuenta de origen:  {Usuario?.tarjetaDebito}\n");
        Console.Write("✋ Por favor, ingrese su NIP. [Si desea cancelar, ingrese: * ]\n--> ");
        for (int i = 0; true; i++)
        {
            if (i == 5)
            {
                Interfaz.MostrarHeader(); // HEADER
                Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
                Console.WriteLine($"\nCuenta de origen:  {Usuario?.tarjetaDebito}\n");
                Console.WriteLine("\n🚫 Ha intentado demasiadas veces.");
                return; // Salir hacia el main
            }
            string? input = Console.ReadLine();
            int nipInput;

            if (input == "*")
            {
                Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                return; // Salir hacia el main
            }
            
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (Validaciones.TryNIPValido(Usuario, input, out nipInput))
                {
                    break; 
                }
            }
            else
            {
                Console.Write("⚠️ Por favor, ingrese su NIP \n--> ");
            }

        }



        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\nCuenta de origen:  {Usuario?.tarjetaDebito}\n");
        Console.WriteLine($"\n🌟 Pago {servicioSeleccionado.Item1} 🌟\n");
        Console.WriteLine($"\n💸 Importe a pagar: ${importe}\n");
        Console.Write("\n\n1.[✅ Continuar con el pago] // 2.[❌ Cancelar operación]\n--> ");
        
        while (true)
            {
                string? input = Console.ReadLine();
                if (input == "2")
                {
                    Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                    return;
                }
                else if (input == "1")
                {
                    
                    Usuario?.PagoServicioUpdate(nombrePropiedad, importe);
                    Usuario?.RetiroDeCuentaUpdate(importe);
                    bool tipo = false;
                    Comprobante.ComprobantePagos(Usuario,importe, servicioSeleccionado, tipo);
                    Interfaz.MostrarHeader(); // HEADER
                    Console.WriteLine("\n✅ Pago exitoso.");
                    Console.WriteLine("\n📃 SE HA IMPRESO SU COMPROBANTE 📃");
                    break;
                }
                else
                {
                    Console.Write("🚫 Seleccione un dato correcto.\n--> ");
                }
            }
        
    }



}