using System.Data.SqlClient;
using ATMStartBank;


public class TransaccionesCliente
{
    public List<Transaccion> Transacciones { get; set; } = new List<Transaccion>();

    // Constructor que acepta una lista de transacciones
    public TransaccionesCliente()
    {
    }

    // Método para cargar transacciones desde la base de datos
    public void CargarTransaccionesDesdeDB(Usuario? usuario)
    {
        var conexionBD = new ConexionBD();
        try
        {
            string Query = $"SELECT id_usuario, fecha, tipo, monto FROM transaccionesCliente{usuario?.id}";

            var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());
            using SqlDataReader lector = cmd.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    this.Transacciones.Add(new Transaccion
                    {
                        IdUsuario = (int)lector["id_usuario"],
                        Fecha = (DateTime)lector["fecha"],
                        Tipo = lector["tipo"].ToString(),
                        Monto = (decimal)lector["monto"]
                    });
                }
            }
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
}

public class Transaccion
{
    public int IdUsuario { get; set; }
    public DateTime Fecha { get; set; }
    public string? Tipo { get; set; }
    public decimal Monto { get; set; }
}
