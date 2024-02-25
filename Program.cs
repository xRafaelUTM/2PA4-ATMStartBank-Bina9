using System.Text;
using System.Data.SqlClient;

namespace prueba_GestionBD;

class Program
{
    
    static void Main(string[] args)
    {
        // Establece la codificación UTF-8 como la codificación predeterminada para todas las operaciones de entrada y salida
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Usuario? Usuario = Usuario.CrearUsuario();
        

    }

    

}
