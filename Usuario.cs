using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

namespace ATMStartBank;

public class Usuario
{
    private int Id;
    private string? Nombres;
    private string? ApellidoPaterno;
    private string? ApellidoMaterno;
    private decimal TarjetaDebito;
    private decimal TarjetaCredito;
    private int PinTarjeta;
    private decimal SaldoTarjetaDebito;
    private decimal SaldoTarjetaCredito;
    private decimal PagoHipotecario;
    private decimal PagoCarro;
    private decimal PagoCFE;
    private decimal PagoTelmex;
    private decimal PagoJapay;
    private decimal PagoTelcel;
    private decimal PagoTotalPlay;
    private decimal PagoColegiatura;

    public Usuario(int Id, string? Nombres, string? ApellidoPaterno, string? ApellidoMaterno, decimal TarjetaDebito, decimal TarjetaCredito, int PinTarjeta, decimal SaldoTarjetaDebito, decimal SaldoTarjetaCredito, decimal PagoHipotecario, decimal PagoCarro, decimal PagoCFE, decimal PagoTelmex, decimal PagoJapay, decimal PagoTelcel, decimal PagoTotalPlay, decimal PagoColegiatura)
    {
        this.Id = Id;
        this.Nombres = Nombres;
        this.ApellidoPaterno = ApellidoPaterno;
        this.ApellidoMaterno = ApellidoMaterno;
        this.TarjetaDebito = TarjetaDebito;
        this.TarjetaCredito = TarjetaCredito;
        this.PinTarjeta = PinTarjeta;
        this.SaldoTarjetaDebito = SaldoTarjetaDebito;
        this.SaldoTarjetaCredito = SaldoTarjetaCredito;
        this.PagoHipotecario = PagoHipotecario;
        this.PagoCarro = PagoCarro;
        this.PagoCFE = PagoCFE;
        this.PagoTelmex = PagoTelmex;
        this.PagoJapay = PagoJapay;
        this.PagoTelcel = PagoTelcel;
        this.PagoTotalPlay = PagoTotalPlay;
        this.PagoColegiatura = PagoColegiatura;
    }

    public static Usuario? CrearUsuario()
    {
        var conexionBD = new ConexionBD();
        decimal tarjeta;
        
        do
        {
            // Ruta 
            string archivoPython = @"./lector_codigo_barras.py";

            // Iniciar el proceso Pyton mano
            Process.Start("python", archivoPython);

            Interfaz.MostrarHeader();
            Console.Write("🔍 Por favor ingrese su Tarjeta\n--> ");
            string? input = Console.ReadLine();

            
            if(Validaciones.ValidarIDNULL(input) && Validaciones.ValidarIDRango(input, out tarjeta))
            {
                break;
            }

            Console.ReadKey();
            Console.Clear();
        } while (true);
        
        try
        {
            string Query = $"SELECT * FROM clientesCuenta WHERE tarjetaDebito = {tarjeta}";
            var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());
            

            using SqlDataReader lector = cmd.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Usuario Usuario = new Usuario((int)lector["Id"], (string)lector["Nombres"], (string)lector["ApellidoPaterno"], (string)lector["ApellidoMaterno"], (decimal)lector["TarjetaDebito"], (decimal)lector["TarjetaCredito"], (int)lector["PinTarjeta"], (decimal)lector["SaldoTarjetaDebito"], (decimal)lector["SaldoTarjetaCredito"], (decimal)lector["PagoHipotecario"], (decimal)lector["PagoCarro"], (decimal)lector["PagoCFE"], (decimal)lector["PagoTelmex"], (decimal)lector["PagoJapay"], (decimal)lector["PagoTelcel"], (decimal)lector["PagoTotalPlay"], (decimal)lector["PagoColegiatura"]); 
                    return Usuario;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
        finally
        {
            conexionBD.CerrarConexion();
        }
        return null;
    }

    public void DepositoUpdate(decimal importe)
    {
        var conexionBD = new ConexionBD();
        
        SaldoTarjetaDebito += importe;

        // Actualizar un saldo UPDATE
        try
        {
            string Query = $"UPDATE clientesCuenta SET saldoTarjetaDebito = {SaldoTarjetaDebito} WHERE id = {Id}"; 
            var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            conexionBD.CerrarConexion();
        }

    }

    public void PagoServicioUpdate(string nombrePropiedad, decimal importe)
    {
        var conexionBD = new ConexionBD();
        PropertyInfo? propiedad = this.GetType().GetProperty(nombrePropiedad);

        #pragma warning disable CS8605 // Conversión unboxing a un valor posiblemente NULL.
        decimal valorActual = (decimal)propiedad?.GetValue(this);
        #pragma warning restore CS8605 // Conversión unboxing a un valor posiblemente NULL.

        decimal nuevoValor = valorActual - importe;
        // Asigna el nuevo valor a la propiedad
        propiedad.SetValue(this, nuevoValor);

        // Actualizar un saldo UPDATE
        try
        {
            string Query = $"UPDATE clientesCuenta SET {nombrePropiedad} = {nuevoValor} WHERE id = {Id}"; 
            var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            conexionBD.CerrarConexion();
        }
    }
    public void RetiroDeCuentaUpdate(decimal importe)
    {
        var conexionBD = new ConexionBD();
        
        SaldoTarjetaDebito -= importe;

        // Actualizar un saldo UPDATE
        try
        {
            string Query = $"UPDATE clientesCuenta SET saldoTarjetaDebito = {SaldoTarjetaDebito} WHERE id = {Id}"; 
            var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            conexionBD.CerrarConexion();
        }
    }
    

    public int id {get => Id; set => Id = value;}
    public string? nombres {get => Nombres; set => Nombres = value;}
    public string? apellidoPaterno { get => ApellidoPaterno; set => ApellidoPaterno = value; }
    public string? apellidoMaterno { get => ApellidoMaterno; set => ApellidoMaterno = value; }
    public decimal tarjetaDebito { get => TarjetaDebito; set => TarjetaDebito = value; }
    public decimal tarjetaCredito { get => TarjetaCredito; set => TarjetaCredito = value; }
    public int pinTarjeta { get => PinTarjeta; set => PinTarjeta = value; }
    public decimal saldoTarjetaDebito { get => SaldoTarjetaDebito; set => SaldoTarjetaDebito = value; }
    public decimal saldoTarjetaCredito { get => SaldoTarjetaCredito; set => SaldoTarjetaCredito = value; }
    public decimal pagoHipotecario { get => PagoHipotecario; set => PagoHipotecario = value; }
    public decimal pagoCarro { get => PagoCarro; set => PagoCarro = value; }
    public decimal pagoCFE { get => PagoCFE; set => PagoCFE = value; }
    public decimal pagoTelmex { get => PagoTelmex; set => PagoTelmex = value; }
    public decimal pagoJapay { get => PagoJapay; set => PagoJapay = value; }
    public decimal pagoTelcel { get => PagoTelcel; set => PagoTelcel = value; }
    public decimal pagoTotalPlay { get => PagoTotalPlay; set => PagoTotalPlay = value; }
    public decimal pagoColegiatura { get => PagoColegiatura; set => PagoColegiatura = value; }
}