using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Controladores
{
    public class Tipo_De_Recinto_Controlador
    {
        public List<Tipo_De_Recinto> listar_tipo_recinto()
        {
            List<Tipo_De_Recinto> tipos = new List<Tipo_De_Recinto>();

            using (var conexion = BaseDeDatos.ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand("sp_ListarTiposDeRecinto", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

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
