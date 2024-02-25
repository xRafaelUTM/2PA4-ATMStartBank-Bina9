using System.Text;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace prueba_GestionBD;

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
        int id;
        
        while (true)
        {
            Console.Clear();

            Interfaz.mostrarHeader();
            Console.Write("🔍 Por favor ingrese su ID\n--> ");
            string? input = Console.ReadLine();
            
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("⚠️  Valor nulo, por favor intente nuevamente [ENTER].");
            }
            else if (!int.TryParse(input, out id))
            {
                Console.WriteLine("⚠️  Valor no aceptado, por favor intente nuevamente [ENTER].");
            }
            else
            {
                int.TryParse(input, out id);
                if ( id < 1 || id > 20)
                {
                    Console.WriteLine("⚠️  Cuenta no encontrada, por favor intente nuevamente [ENTER].");
                }
                else
                {
                    break;
                }
            }
            Console.ReadKey();
        }
        
        try
        {
            string Query = $"SELECT * FROM clientesCuenta WHERE id = {id}";
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