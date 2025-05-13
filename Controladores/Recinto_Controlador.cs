using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Controladores
{
    public class Recinto_Controlador
    {
        public int agregar_recinto(int numero, decimal tarifa, string ubicacion, int id_tipo)
        {
            try
            {
                using (SqlConnection conexion = BaseDeDatos.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("sp_AgregarRecinto", conexion))
                    {
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@nro_recinto", numero);
                        comando.Parameters.AddWithValue("@tarifa_hora", tarifa);
                        comando.Parameters.AddWithValue("@ubicacion_recinto", ubicacion);
                        comando.Parameters.AddWithValue("@id_tipo_recinto", id_tipo);

                        conexion.Open();
                        return comando.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    throw new Exception("Ya existe un recinto registrado con ese número.");
                else
                    throw new Exception("Error en la base de datos: " + ex.Message);
            }
        }

        public static int verificar_recinto(int numero)
        {
            return obtener_recinto_por_numero(numero) == null ? 0 : -1;
        }


        public List<Recinto> ObtenerTodosLosRecintos()
        {
            List<Recinto> recintos = new List<Recinto>();


            using (SqlConnection conexion = BaseDeDatos.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ObtenerTodosLosRecintos", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            recintos.Add(new Recinto
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
                            });
                        }
                    }
                }
            }

            return recintos;
        }

        public static Recinto obtener_recinto_por_numero(int numeroRecinto)
        {
            Recinto recinto = null;

            using (SqlConnection conexion = BaseDeDatos.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerRecintoPorNumero", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nro_recinto", numeroRecinto);

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
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

        public void HabilitarRecintoPorNumero(int numeroRecinto)
        {
            using (SqlConnection conexion = BaseDeDatos.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_HabilitarRecinto", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nro_recinto", numeroRecinto);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeshabilitarRecintoPorNumero(int numeroRecinto)
        {
            using (SqlConnection conexion = BaseDeDatos.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeshabilitarRecinto", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nro_recinto", numeroRecinto);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int actualizar_recinto(int numeroRecinto, decimal tarifa, string ubicacion, int id_tipo_recinto)
        {
            try
            {
                using (SqlConnection conexion = BaseDeDatos.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarRecinto", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nro_recinto", numeroRecinto);
                        cmd.Parameters.AddWithValue("@tarifa_hora", tarifa);
                        cmd.Parameters.AddWithValue("@ubicacion_recinto", ubicacion);
                        cmd.Parameters.AddWithValue("@id_tipo_recinto", id_tipo_recinto);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
