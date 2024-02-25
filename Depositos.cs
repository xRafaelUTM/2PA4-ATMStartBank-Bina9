using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;

namespace ATMStartBank;


public static class Depositos
{
    public static void RealizarDeposito(Usuario? usuario)
    {
        Interfaz.MostrarHeader(); // HEADER
        Interfaz.DatosDepositoTarjeta(usuario);

        decimal importe;
        while (true)
        {
            Console.Write("💲 Ingrese el importe a depositar. [Si desea cancelar, ingrese: * ]\n--> ");
            string? input = Console.ReadLine();

            if (input == "*")
            {
                Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                return; // Salir hacia el main
            }
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (Validaciones.TryObtenerImporte(input, out importe) && Validaciones.ValidarImporte(importe))
                {
                    Interfaz.MostrarHeader(); // HEADER
                    Interfaz.DatosDepositoTarjetaImporte(usuario, importe);

                    string motivo = ObtenerMotivoDeposito();

                    if (motivo == "*")
                    {
                        Console.WriteLine("\n🚫 El usuario ha cancelado la operación.");
                        return;
                    }
                    else
                    {
                        Interfaz.MostrarHeader(); // HEADER
                        Console.WriteLine("\n\t🌟 DATOS DEL DEPÓSITO 🌟\n");
                        Console.WriteLine($"💳 Tarjeta: \t{usuario?.tarjetaDebito}\n");
                        Console.WriteLine($"💰 Importe: \t{importe:C}\n");
                        Console.WriteLine($"📝 Motivo: \t{motivo}\n");

                        if (ConfirmarDatos())
                        {
                            usuario?.DepositoUpdate(usuario, importe);
                            Comprobante.ComprobanteDepositos(usuario, importe, motivo);
                            Interfaz.MostrarHeader(); // HEADER
                            Console.WriteLine("\n✅ Depósito exitoso.");
                            Console.WriteLine("\n📃 SE HA IMPRESO SU COMPROBANTE 📃");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("⚠️ Por favor, ingrese un importe válido.");
            }
        }
    }

    private static string ObtenerMotivoDeposito()
    {
        Console.Write("❕ Ingrese el motivo de pago. [Si desea cancelar, ingrese: * ]\n--> ");
        string? input = Console.ReadLine();
        return input ?? string.Empty;
    }

    private static bool ConfirmarDatos()
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