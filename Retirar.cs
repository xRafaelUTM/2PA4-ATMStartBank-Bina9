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
                    MostrarMenuOpciones(Usuario, Atm);
                    return;
                default:
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


    public static void MostrarMenuOpciones(Usuario? Usuario, Atm? Atm)
    {
        Interfaz.MostrarHeader(); // HEADER
        Console.WriteLine($"\nTitular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}\n");
        Console.WriteLine($"\n💳 Cuenta: {Usuario?.tarjetaDebito}\n");
        Console.WriteLine("1. 💳 Consultar movimientos");
        Console.WriteLine("2. 💸 Cambiar NIP");
        Console.WriteLine("3. ❌ Salir");
        Console.Write("--> ");
        string? opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                // Aquí se implementaría la lógica para mostrar los movimientos
                Console.WriteLine("\nMostrando movimientos...");
                break;
            case "2":
                // Aquí se implementaría la lógica para cambiar el NIP
                Console.WriteLine("\nCambio de NIP...");
                break;
            default:
                Console.WriteLine("\nOpción no válida.");
                break;
        }
    }

        

}
