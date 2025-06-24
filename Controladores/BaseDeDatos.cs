using System.Configuration;
using System.Data.SqlClient;

namespace Controladores
{
    public class BaseDeDatos
    {
        private static BaseDeDatos _instancia;
        private static readonly object _lock = new object();
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;



        // Constructor privado para Singleton
        private BaseDeDatos() { }

        // Propiedad pública para acceder a la instancia
        public static BaseDeDatos Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new BaseDeDatos();

                    return _instancia;
                }
            }
        }

        // Retorna una nueva conexión lista para usar
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
