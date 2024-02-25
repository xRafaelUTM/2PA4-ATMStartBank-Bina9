using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;

namespace ATMStartBank;

public class ConexionBD
{
    
    private string conexionString = "Server=DESKTOP-KEI8B51;Database=clientesBank;Integrated Security=True;";
    public SqlConnection conexion;
    public ConexionBD()
    {
        conexion = new SqlConnection(conexionString);
    }
    public SqlConnection? AbrirConexion()
    {
        try
        {
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al establecer conexión: {ex}");
            return null;
        }
    }
    public SqlConnection CerrarConexion()
    {
        conexion.Close();
        return conexion;
    }

}
