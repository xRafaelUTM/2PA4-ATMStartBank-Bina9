using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;
public static class Comprobante
{
    public static void ComprobanteDepositos(Usuario? Usuario, decimal importe, string? motivo)
    {
        
        string fecha = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");

        TextWriter comprobanteDeposito = new StreamWriter($"./comprobantes/Comprobante-{fecha}--IDCliente-{Usuario?.id}-.txt");

        string texto = $"""

        ╔═════════════════╗
        ║      💵   ATM SARTBANK   💵      ║
        ╚═════════════════╝
            
                📃 DEPOSITO 📃

        📆 Fecha:   {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}
        🧑 Titular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}
        💳 Tarjeta: {Usuario?.tarjetaDebito}
        💰 Importe: {importe:C}
        📝 Motivo:  {motivo}

                *CUALQUIER ACLARACION ACUDE
                CON TU RAFITA MAS CERCANO*
        """;

        comprobanteDeposito.WriteLine(texto);
        comprobanteDeposito.Close();

    }
}