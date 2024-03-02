using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using ATMStartBank;
using System.Text;
using System.Collections.Generic;

namespace ATMStartBank;

public class Atm
{
    private decimal Efectivo;
    public Atm(decimal Efectivo)
    {
        this.Efectivo = Efectivo;
    }

    public static Atm? EfectivoInicio()
    {
        var conexionBD = new ConexionBD();

        try
        {
            string Query = $"SELECT * FROM atmEfectivo";
            var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());
            
            using SqlDataReader lector = cmd.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Atm Atm = new Atm((decimal)lector["efectivoDisponible"]); 
                    return Atm;
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

    public void EfectivoDepositoUpdate(decimal importe)
    {
        var conexionBD = new ConexionBD();
        Efectivo += importe;

        // Actualizar un saldo UPDATE
        try
        {
            string Query = $"UPDATE atmEfectivo SET efectivoDisponible = {Efectivo} "; 
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
    public void EfectivoRetiroUpdate(decimal importe)
    {
        var conexionBD = new ConexionBD();
        Efectivo -= importe;

        // Actualizar un saldo UPDATE
        try
        {
            string Query = $"UPDATE atmEfectivo SET efectivoDisponible = {Efectivo} "; 
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

    public decimal efectivo {get => Efectivo; set => Efectivo = value;}
}
