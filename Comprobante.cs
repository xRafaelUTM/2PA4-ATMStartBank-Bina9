using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;        
using ATMStartBank;
using System.Text;
using System.Collections.Generic;

public static class Comprobante
{
    public static void ComprobanteDepositos(Usuario? Usuario, decimal importe, string? motivo)
    {
        string fechaFormatoHistoriar = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");  
        Usuario?.InsertarDespositoHistorial(fechaFormatoHistoriar, importe);

        string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        TextWriter comprobanteDeposito = new StreamWriter($"./comprobantes/Comprobante-{fecha}--IDCliente-{Usuario?.id}-.txt");
        
        string texto = $"""

        ╔════════════════════════════╗
        ║      💵   ATM SARTBANK   💵      ║
        ╚════════════════════════════╝
            
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

    public static void ComprobantePagos(Usuario? Usuario, decimal importe, Tuple<string, string> servicioSeleccionado, bool tipo)
    {
        string? TipoDePago;
        if (tipo == true)
        {
                TipoDePago = "Efectivo";
        }
        else
        {
                TipoDePago = "Transacción";

                
        }
        string fechaFormatoHistoriar = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");  
        Usuario?.InsertarPagoHistorial(fechaFormatoHistoriar, importe, servicioSeleccionado, TipoDePago);
        
        string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        TextWriter comprobanteDeposito = new StreamWriter($"./comprobantes/Comprobante-{fecha}--IDCliente-{Usuario?.id}-.txt");

        string texto = $"""

        ╔════════════════════════════╗
        ║      💵   ATM SARTBANK   💵      ║
        ╚════════════════════════════╝
            
                📃 PAGO DE SERVICIO 📃

        📆 Fecha:   {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}
        🧑 Titular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}
        💳 Tarjeta: {Usuario?.tarjetaDebito}
        🧾 Pago {servicioSeleccionado.Item1}
        💲 Tipo de pago: {TipoDePago}
        💰 Importe: {importe:C}

                *CUALQUIER ACLARACION ACUDE
                CON TU RAFITA MAS CERCANO*
        """;


        comprobanteDeposito.WriteLine(texto);
        comprobanteDeposito.Close();

    }

        public static void ComprobanteRetiro(Usuario? Usuario, decimal montoRetiro)
        {
                string fechaFormatoHistoriar = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");  
                Usuario?.InsertarRetiroHistorial(fechaFormatoHistoriar, montoRetiro);
                
                string fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

                TextWriter comprobanteDeposito = new StreamWriter($"./comprobantes/Comprobante-{fecha}--IDCliente-{Usuario?.id}-.txt");
                
                string texto = $"""

                ╔════════════════════════════╗
                ║      💵   ATM SARTBANK   💵      ║
                ╚════════════════════════════╝
                
                        📃 RETIRO DE EFECTIVO 📃

                📆 Fecha:   {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}
                🧑 Titular:  {Usuario?.nombres} {Usuario?.apellidoPaterno} {Usuario?.apellidoMaterno}
                💳 Tarjeta: {Usuario?.tarjetaDebito}
                💰 Monto: {montoRetiro:C}

                        *CUALQUIER ACLARACION ACUDE
                        CON TU RAFITA MAS CERCANO*
                """;

                comprobanteDeposito.WriteLine(texto);
                comprobanteDeposito.Close();
        }

}