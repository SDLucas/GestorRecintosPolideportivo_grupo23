using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class Recinto_Controlador
    {
        private readonly BaseDeDatos db = new BaseDeDatos();

        public int validar_datos(int numero, decimal tarifa, int id_tipo, string ubicacion)
        {
            int resultado = 0;
            if (verificar_recinto(numero) != 0)
            {
                return -1;
            }
            return resultado;
        }

        public int agregar_recinto(int numero, decimal tarifa, string ubicacion, int id_tipo)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection conexion = BaseDeDatos.ObtenerConexion())
                {
                    String query = "insert into recinto(nro_recinto,tarifa_hora,ubicacion_recinto,id_tipo_recinto) \r\nvalues\r\n(" +
                        numero + "," + tarifa + ",'" + ubicacion + "'," + id_tipo + ");";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    conexion.Open();
                    resultado = comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Código de error 2627 o 2601 normalmente indica violación de una restricción de clave única
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("Ya existe un recinto registrado con ese numero registrado.");
                }
                else
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }

            return resultado;
        }

        public static int verificar_recinto(int numero)
        {
            if (Recinto_Controlador.obtener_recinto_por_numero(numero) == null)
            {
                //no hay recinto con ese numero
                return 0;
            }

            return -1;
        }

        public List<Recinto> ObtenerTodosLosRecintos()
        {
            List<Recinto> recintos = new List<Recinto>();

            using (var conexion = BaseDeDatos.ObtenerConexion())
            {
                conexion.Open();
                string query = @"SELECT r.nro_recinto, r.tarifa_hora, r.ubicacion_recinto, r.habilitado,
                                        t.id_tipo_recinto, t.nombre_tipo_recinto
                                 FROM Recinto r
                                 INNER JOIN Tipo_Recinto t ON r.id_tipo_recinto = t.id_tipo_recinto";

                using (var comando = new SqlCommand(query, conexion))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            recintos.Add(new Recinto
                            {
                                NumeroRecinto = (int)reader["nro_recinto"],
                                Tarifa = Convert.ToDecimal(reader["tarifa_hora"]), //convierto de FLOAT a decimal
                                Ubicacion = reader["ubicacion_recinto"].ToString(),
                                Habilitado = (bool)reader["habilitado"],
                                TipoRecinto = new Tipo_De_Recinto
                                {
                                    id_tipo_recinto = (int)reader["id_tipo_recinto"],
                                    nombre_tipo_recinto = reader["nombre_tipo_recinto"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            return recintos;
        }

        public void HabilitarRecintoPorNumero(int numeroRecinto)
        {
            using (var conexion = BaseDeDatos.ObtenerConexion())
            {
                conexion.Open();
                string query = "UPDATE Recinto SET habilitado = 1 WHERE nro_recinto = @numero";
                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@numero", numeroRecinto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeshabilitarRecintoPorNumero(int numeroRecinto)
        {
            using (var conexion = BaseDeDatos.ObtenerConexion())
            {
                conexion.Open();
                string query = "UPDATE Recinto SET habilitado = 0 WHERE nro_recinto = @numero";
                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@numero", numeroRecinto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Recinto obtener_recinto_por_numero(int numeroRecinto)
        {
            Recinto recinto = null;

            using (var conexion = BaseDeDatos.ObtenerConexion())
            {
                conexion.Open();
                string query = @"SELECT r.nro_recinto, r.tarifa_hora, r.ubicacion_recinto, r.habilitado,
                                        t.id_tipo_recinto, t.nombre_tipo_recinto
                                 FROM Recinto r
                                 INNER JOIN Tipo_Recinto t ON r.id_tipo_recinto = t.id_tipo_recinto
                                 WHERE r.nro_recinto = @numeroRecinto";

                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@numeroRecinto", numeroRecinto);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            recinto = new Recinto
                            {
                                NumeroRecinto = (int)reader["nro_recinto"],
                                Tarifa = Convert.ToDecimal(reader["tarifa_hora"]),
                                Ubicacion = reader["ubicacion_recinto"].ToString(),
                                Habilitado = (bool)reader["habilitado"],
                                TipoRecinto = new Tipo_De_Recinto
                                {
                                    id_tipo_recinto = (int)reader["id_tipo_recinto"],
                                    nombre_tipo_recinto = reader["nombre_tipo_recinto"].ToString()
                                }
                            };
                        }
                    }
                }
            }

            return recinto;
        }

        public int actualizar_recinto(int numeroRecinto, decimal tarifa, string ubicacion, int id_tipo_recinto)
        {
            try
            {
                using (var conexion = BaseDeDatos.ObtenerConexion())
                {
                    conexion.Open();
                    string query = @"UPDATE Recinto
                                     SET tarifa_hora = @tarifa,
                                         ubicacion_recinto = @ubicacion,
                                         id_tipo_recinto = @id_tipo
                                     WHERE nro_recinto = @numeroRecinto";

                    using (var cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@tarifa", tarifa);
                        cmd.Parameters.AddWithValue("@ubicacion", ubicacion);
                        cmd.Parameters.AddWithValue("@id_tipo", id_tipo_recinto);
                        cmd.Parameters.AddWithValue("@numeroRecinto", numeroRecinto);

                        cmd.ExecuteNonQuery();
                    }
                }

                return 0; // 0 = éxito
            }
            catch (Exception)
            {
                return 1; // 1 = error
            }
        }

    }
}
