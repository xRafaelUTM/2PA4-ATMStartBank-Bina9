using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;
using System.Collections.Generic;

namespace ATMStartBank;
public class Validaciones
{
    internal static int input;

    public static bool ValidarIDNULL(string? input)
    {
        
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("⚠️  Valor nulo, por favor intente nuevamente [ENTER].");
            return false;
        }
        else if (!decimal.TryParse(input,out _))
        {
            Console.WriteLine("⚠️  Valor no aceptado, por favor intente nuevamente [ENTER].");
            return false;
        }

        return true;
    }

    public static bool ValidarIDRango(string? input, out decimal tarjeta)
    {
        tarjeta = Convert.ToDecimal(input);


        List<string?> numerosTarjeta = new List<string?>
        {
            "5786709677231470",
            "5752012256582762",
            "5722171528569223",
            "5585534185761346",
            "5572136128787799",
            "5716747958312739",
            "5912219448252724",
            "5871410557766564",
            "5923175728438364",
            "5786708914231470",
            "5722964960389093",
            "5786709254919470",
            "5786709712218505",
            "5786709212231470",
            "5786709629361499",
            "5786709677231471",
            "5786709677231271",
            "5786709549131672",
            "5786709677231573",
            "5786709596831454"
        };

        
        bool boleano = numerosTarjeta.Contains(input);

        if (boleano == false)
        {
            Console.WriteLine("⚠️  Valor no encontrado, por favor intente nuevamente [ENTER].");
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool TryObtenerImporte(string input, out decimal importe)
    {
        importe = 0;

        if (input == "*")
        {
            return false;
        }

        try
        {
            importe = Convert.ToDecimal(input);
            return true;
        }
        catch (FormatException)
        {
            Console.WriteLine("⚠️ Formato incorrecto. Por favor, ingrese un número válido.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("⚠️ El importe ingresado es demasiado grande o demasiado pequeño. Por favor, ingrese un valor válido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error: {ex.Message}");
        }

        return false;
    }

    public static bool ValidarImporte(decimal importe)
    {
        if(importe > 40000)
        {
            Console.WriteLine("⚠️ El importe debe ser menor a $40,000. Por favor, intente nuevamente.");
            return false; 
        }

        if (importe <= 0)
        {
            Console.WriteLine("⚠️ El importe debe ser mayor que cero. Por favor, intente nuevamente.");
            return false;
        }

        if (importe % 20 != 0 && importe % 50 != 0 && importe % 100 != 0 && importe % 200 != 0 && importe % 500 != 0 && importe % 1000 != 0)
        {
            Console.WriteLine("⚠️ El importe debe ser un valor ingresado por billetes (20, 50, 100, 200, 500, 1000). Por favor, inténtelo nuevamente.");
            return false;
        }

        return true;
    }

    public static bool TryNIPValido(Usuario? Usuario, string input, out int nipInput)
    {
        nipInput = 0;

        try
        {
            nipInput = Convert.ToInt32(input);
            if (nipInput == Usuario?.pinTarjeta)
            {
                return true;
            }
            else
            {
                Console.Write("⚠️  NIP incorrecto. Por favor, ingrese su NIP correctamente.\n--> ");
            }
            
        }
        catch (FormatException)
        {
            Console.Write("⚠️  Formato incorrecto. Por favor, ingrese un NIP válido.\n--> ");
        }
        catch (OverflowException)
        {
            Console.Write("⚠️  El NIP ingresado es demasiado grande o demasiado pequeño. Por favor, ingrese un NIP válido.\n--> ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error: {ex.Message}");
        }

        
        return false;
    }

    public static bool ConfirmarDatos()
    {
        Console.Write("❕ ¿Todos los datos son correctos?. \n\n1.[✅ Continuar] // 2.[❌ Cancelar operación]\n--> ");

        while (true)
        {
            string? input = Console.ReadLine();
            if (input == "2")
            {
                Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                return false;
            }
            else if (input == "1")
            {
                return true;
            }
            else
            {
                Console.Write("🚫 Seleccione un dato correcto.\n--> ");
            }
        }
    }

}
