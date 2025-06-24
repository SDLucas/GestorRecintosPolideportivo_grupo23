using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class Medio_Pago_Controlador
    {
        //llamada al procedimiento almacenado para listar todos los medios de pago
        public List<Medio_Pago> listar_medios_pago()
        {
            List<Medio_Pago> medios = new List<Medio_Pago>();

            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ListarMediosDePago", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medios.Add(new Medio_Pago
                        {
                            id_medio = (int)reader["id_medio"],
                            nombre_medio = reader["nombre_medio"].ToString()
                        });
                    }
                }
                conexion.Close();
            }

            return medios;
        }
    }
}
