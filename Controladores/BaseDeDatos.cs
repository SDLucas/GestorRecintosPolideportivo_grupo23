using System.Data.SqlClient;

namespace Controladores
{
    public static class BaseDeDatos
    {
        // Cadena de conexión inicializada directamente
        private static readonly string cadenaConexion = "Server=DESKTOP-250LNCS\\SQLEXPRESS;Database=polideportivoDev;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
