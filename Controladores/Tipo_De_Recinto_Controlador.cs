using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class Tipo_De_Recinto_Controlador
    {
        private readonly BaseDeDatos db = new BaseDeDatos();

        // Método para traer dinámicamente los tipos de recinto
        public List<Modelos.Tipo_De_Recinto> listar_tipo_recinto()
        {
            List<Tipo_De_Recinto> tipos = new List<Tipo_De_Recinto>();

            using (var conexion = BaseDeDatos.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT id_tipo_recinto, nombre_tipo_recinto FROM Tipo_Recinto";

                using (var comando = new SqlCommand(query, conexion))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tipos.Add(new Tipo_De_Recinto
                            {
                                id_tipo_recinto = (int)reader["id_tipo_recinto"],
                                nombre_tipo_recinto = reader["nombre_tipo_recinto"].ToString()
                            });
                        }
                    }
                }
            }

            return tipos;
        }
    }
}
