using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;

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
        else if (!int.TryParse(input, out _))
        {
            Console.WriteLine("⚠️  Valor no aceptado, por favor intente nuevamente [ENTER].");
            return false;
        }

        return true;
    }

    public static bool ValidarIDRango(string? input, out int id)
    {
        id = Convert.ToInt32(input);

        if (id < 1 || id > 20)
        {
            Console.WriteLine("⚠️  Cuenta no encontrada, por favor intente nuevamente [ENTER].");
            return false;
        }

        return true;
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
    
}
