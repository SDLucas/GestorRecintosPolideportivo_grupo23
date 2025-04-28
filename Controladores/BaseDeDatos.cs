using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Controladores
{
    public class BaseDeDatos
    {
        private static string cadenaConexion;

        public BaseDeDatos()
        {
            cadenaConexion = "Server=DESKTOP-250LNCS\\SQLEXPRESS;Database=polideportivoDev;Trusted_Connection=True;";
        }

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
