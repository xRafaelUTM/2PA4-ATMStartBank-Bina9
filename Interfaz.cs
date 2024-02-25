namespace ATMStartBank;
public class Interfaz
{
    public static void MostrarHeader()
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════╗");
        Console.WriteLine("║      💵   ATM SARTBANK   💵       ║");
        Console.WriteLine("╚═══════════════════════════════════╝");
    }

    public static void DatosDepositoTarjeta(Usuario? Usuario)
    {
        Console.WriteLine("\n\t🌟 DATOS DEL DEPÓSITO 🌟\n");
        Console.WriteLine($"💳 Tarjeta: \t{Usuario?.tarjetaDebito}\n");
    }

    public static void DatosDepositoTarjetaImporte(Usuario? Usuario, decimal importe)
    {
        Console.WriteLine("\n\t🌟 DATOS DEL DEPÓSITO 🌟\n");
        Console.WriteLine($"💳 Tarjeta: \t{Usuario?.tarjetaDebito}\n");
        Console.WriteLine($"💰 Importe: \t{importe:C}\n");
    }

    public static void DatosDepositoTarjetaImporteMotivo(Usuario? Usuario, decimal importe, string? input)
    {
        Console.WriteLine("\n\t🌟 DATOS DEL DEPÓSITO 🌟\n");
        Console.WriteLine($"💳 Tarjeta: \t{Usuario?.tarjetaDebito}\n");
        Console.WriteLine($"💰 Importe: \t{importe:C}\n");
        Console.WriteLine($"📝 Motivo: \t{input}\n");
    }
}