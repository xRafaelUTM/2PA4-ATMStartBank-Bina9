using ATMStartBank;

class Retirar
{
    public static void IngresarIRetiro(Usuario? Usuario, Atm? Atm)
    {
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\n ¡HOLA {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}!\n");
        Console.Write("✋ Por favor, ingrese su NIP. [Si desea cancelar, ingrese: * ]\n--> ");
        for (int i = 0; true; i++)
        {
            if (i == 5)
            {
                Interfaz.MostrarHeader(); // HEADER
                Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
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
        MenuRetiro(Usuario, Atm);
    }

    public static void MenuRetiro(Usuario? Usuario, Atm? Atm)
    {
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n💳 Cuenta: {Usuario?.tarjetaDebito}");
        Console.WriteLine($"\n💵 Tu saldo es: ${Usuario?.saldoTarjetaDebito}");
        // Calcula y muestra el monto máximo que se puede retirar
        decimal montoMaximoRetirable = CalcularMontoMaximoRetirable(Usuario?.saldoTarjetaDebito ?? 0);
        Console.WriteLine($"\n💰 Puedes retirar hasta: ${montoMaximoRetirable}");
        Console.Write($"\n💲 Ingresa el monto que deseas retirar. \n[Para salir ingrese un * ] \n[Para mas opciones (Consultar movimientos, cambiar NIP) ingrese un +]\n --> ");

        while (true)
        {
            string? input = Console.ReadLine();

            switch (input)
            {
                case "*":
                    Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                    return;
                case "+":
                    MostrarMenuOpciones(Usuario);
                    return;
                default:
                    if (montoMaximoRetirable < 20){Console.Write("\n🚫 No tiene saldo disponible para retirar.\nSeleccione otra opción --> "); break;}
                    else
                    {
                    if (decimal.TryParse(input, out decimal montoRetiro) && montoRetiro > 0)
                    {
                        if (montoRetiro <= montoMaximoRetirable && EsMontoRetirable(montoRetiro))
                        {
                            if (Validaciones.ConfirmarDatos())
                            {
                                Interfaz.MostrarHeader(); // HEADER
                                string desgloseBilletes = DesgloseMontoRetiro(montoRetiro);
                                Console.WriteLine($"\nHas retirado {montoRetiro:C}. \nSe retiró{desgloseBilletes}. \nPor favor recoge tu dinero [ENTER].");
                                Console.ReadKey();
                                Usuario?.RetiroDeCuentaUpdate(montoRetiro);
                                Atm?.EfectivoRetiroUpdate(montoRetiro);
                                Comprobante.ComprobanteRetiro(Usuario, montoRetiro);
                                Interfaz.MostrarHeader(); // HEADER
                                Console.WriteLine("\n✅ Retiro exitoso.");
                                Console.WriteLine("\n📃 SE HA IMPRESO SU COMPROBANTE 📃");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                                return;   
                            }
        
                        }
                        else
                        {
                            Console.Write("\n⚠️ El monto a retirar no es válido [EL ATM SOLO ENTREGA BILLETES]. \nIntente de nuevo. --> ");
                        }
                    }
                    else
                    {
                        Console.Write("\n⚠️ Entrada no válida. Intente de nuevo. --> ");
                    }
                    break;
                    }
            }
        }
    }

    static decimal CalcularMontoMaximoRetirable(decimal saldo)
    {
        // Monto máximo permitido por seguridad
        const decimal montoSeguridad = 9000M;

        // El saldo debe ser ajustado a múltiplos de las denominaciones de billetes
        decimal montoAjustado = saldo - (saldo % 20);

        // Aplica el límite de seguridad
        return Math.Min(montoAjustado, montoSeguridad);
    }
    
    static bool EsMontoRetirable(decimal importe)
    {
       if (importe % 20 != 0 && importe % 50 != 0 && importe % 100 != 0 && importe % 200 != 0 && importe % 500 != 0 && importe % 1000 != 0)
        {
            return false;
        }

        return true;
    }


    static string DesgloseMontoRetiro(decimal monto)
    {
        int[] denominaciones = new int[] { 1000, 500, 200, 100, 50, 20 };
        decimal montoRestante = monto;
        string desglose = "";

        foreach (int denominacion in denominaciones)
        {
            if (montoRestante == 60)
            {
                desglose += $" 3 billete(s) de 20 y";
                break;
                
            }
            else
            {
                int cantidadBilletes = (int)(montoRestante / denominacion);
                montoRestante -= cantidadBilletes * denominacion;
        
                if (cantidadBilletes > 0)
                {
                    desglose += $" {cantidadBilletes} billete(s) de {denominacion} y";
                }
                
            }
        }
        
        // Remueve el último " y" de la cadena
        if (desglose.EndsWith(" y"))
        {
            desglose = desglose.Substring(0, desglose.Length - 2);
        }

        return desglose;
    }


    public static void MostrarMenuOpciones(Usuario? Usuario)
    {
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n💳 Cuenta: {Usuario?.tarjetaDebito}\n");
        Console.WriteLine("1. 💳 Consultar movimientos");
        Console.WriteLine("2. 💸 Cambiar NIP");
        Console.WriteLine("3. ❌ Salir");
        Console.Write("--> ");

        while (true)
        {
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Aquí se implementaría la lógica para mostrar los movimientos
                    MostrarMovimientos(Usuario);
                    return;
                case "2":
                    //Cambiar el NIP
                    CambiarNip(Usuario);
                    return;

                case "3":
                    return;
            
                default:
                    Console.WriteLine("\nOpción no válida.");
                    break;
            }
            return;
            
        }
        
    }
    public static void CambiarNip(Usuario? Usuario)
    {
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nPor seguridad, recuerde su NIP al momento de cambiarlo.\n");
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n💳 Cuenta: {Usuario?.tarjetaDebito}\n");
        Console.Write("\nIngrese su nuevo NIP [Para cancelar ingrese *]\n--> ");
        int NuevoPin;
        while (true)
        {
            string? input = Console.ReadLine();

            if (input == "*")
            {
                Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                return; // Salir hacia el main
            }
            if (!string.IsNullOrWhiteSpace(input) && Validaciones.ValidarNuevoNip(Usuario, input, out NuevoPin))
            {
                Interfaz.MostrarHeader(); // HEADER
                Console.WriteLine($"\nPor seguridad, recuerde su NIP al momento de cambiarlo.\n");
                Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
                Console.WriteLine($"\n💳 Cuenta: {Usuario?.tarjetaDebito}\n");
                Console.Write("❕ ¿Estas seguro de cambiar tu NIP?. \n1.[✅ Continuar] // 2.[❌ Cancelar operación]\n--> ");
                while (true)
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                        Usuario?.NIPUptade(NuevoPin);
                        Console.WriteLine("\n✅ Su NIP se ha actualizado. ✅");
                        return;

                        case "2":
                        Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                        return;   
                        
                        default:
                        Console.Write("\n🚫 Opción no valida, intente de nuevo.\n--> ");
                        break;
                    }
                    
                }
            }
            else
            {
                Console.Write("🚫 Error, intente de nuevo. \n--> ");
            }
        }
    }

   public static void MostrarMovimientos(Usuario? Usuario)
    {
        TransaccionesCliente transaccionesCliente = new TransaccionesCliente();
        transaccionesCliente.CargarTransaccionesDesdeDB(Usuario);

        // Muestra inicialmente el historial en el orden por defecto.
        MostrarTransacciones(transaccionesCliente, Usuario);

        string? opcion = "";
        do
        {
            Console.WriteLine("\nSeleccione una opción para ordenar el historial:");
            Console.WriteLine("1. Ordenar por montos mayores");
            Console.WriteLine("2. Ordenar por montos menores");
            Console.WriteLine("3. Salir");
            Console.Write("--> ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    transaccionesCliente.Transacciones.Sort((x, y) => y.Monto.CompareTo(x.Monto));
                    MostrarTransacciones(transaccionesCliente, Usuario);
                    break;
                case "2":
                    transaccionesCliente.Transacciones.Sort((x, y) => x.Monto.CompareTo(y.Monto));
                    MostrarTransacciones(transaccionesCliente, Usuario);
                    break;
                case "3":
                    break;
                default:
                    MostrarTransacciones(transaccionesCliente, Usuario);
                    break;
            }
        } while (opcion != "3");
    }

    private static void MostrarTransacciones(TransaccionesCliente transaccionesCliente, Usuario? Usuario)
    {
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n💳 Cuenta: {Usuario?.tarjetaDebito}\n");
        Console.WriteLine($"\n📃 Historial de transacciones");
        Console.WriteLine($"📃 Fecha \t\t📋 Tipo \t\t💵 Monto");
        foreach (var transaccion in transaccionesCliente.Transacciones)
        {
            Console.WriteLine($"📃 {transaccion.Fecha} \t📋 {transaccion.Tipo} \t💵 ${transaccion.Monto}");
        }
    }

}
