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
                using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("sp_AgregarRecinto", conexion))
                    {
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@nro_recinto", numero);
                        comando.Parameters.AddWithValue("@tarifa_hora", tarifa);
                        comando.Parameters.AddWithValue("@ubicacion_recinto", ubicacion);
                        comando.Parameters.AddWithValue("@id_tipo_recinto", id_tipo);

                        conexion.Open();

                        int resultado = comando.ExecuteNonQuery();
                        conexion.Close();

                        return resultado;
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

        public List<Recinto> listar_recintos_habilitados()
        {
            List<Recinto> recintos = new List<Recinto>();


            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ObtenerRecintosHabilitados", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            recintos.Add(new Recinto
                            {
                                nro_recinto = (int)reader["nro_recinto"],
                                tarifa_hora = (float)(double)reader["tarifa_hora"],
                                ubicacion_recinto = reader["ubicacion_recinto"].ToString(),
                                habilitado = (bool)reader["habilitado"],
                                tipo_recinto = new Tipo_De_Recinto
                                {
                                    id_tipo_recinto = (int)reader["id_tipo_recinto"],
                                    nombre_tipo_recinto = reader["nombre_tipo_recinto"].ToString()
                                }
                            });
                        }
                    }
                    conexion.Close();
                }
            }

            return recintos;
        }

        public List<Recinto> listar_recintos()
        {
            List<Recinto> recintos = new List<Recinto>();


            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
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
                                nro_recinto = (int)reader["nro_recinto"],
                                tarifa_hora = (float)(double)reader["tarifa_hora"],
                                ubicacion_recinto = reader["ubicacion_recinto"].ToString(),
                                habilitado = (bool)reader["habilitado"],
                                tipo_recinto = new Tipo_De_Recinto
                                {
                                    id_tipo_recinto = (int)reader["id_tipo_recinto"],
                                    nombre_tipo_recinto = reader["nombre_tipo_recinto"].ToString()
                                }
                            });
                        }
                    }
                    conexion.Close();
                }
            }

            return recintos;
        }

        public static Recinto obtener_recinto_por_numero(int numeroRecinto)
        {
            Recinto recinto = null;

            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
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
                                nro_recinto = (int)reader["nro_recinto"],
                                tarifa_hora = (float)(double)reader["tarifa_hora"],
                                ubicacion_recinto = reader["ubicacion_recinto"].ToString(),
                                habilitado = (bool)reader["habilitado"],
                                tipo_recinto = new Tipo_De_Recinto
                                {
                                    id_tipo_recinto = (int)reader["id_tipo_recinto"],
                                    nombre_tipo_recinto = reader["nombre_tipo_recinto"].ToString()
                                }
                            };
                        }
                    }
                    conexion.Close();
                }
            }

            return recinto;
        }

        public void HabilitarRecintoPorNumero(int numeroRecinto)
        {
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_HabilitarRecinto", conexion))
                {
                    conexion.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nro_recinto", numeroRecinto);

                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

        public void DeshabilitarRecintoPorNumero(int numeroRecinto)
        {
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeshabilitarRecinto", conexion))
                {
                    conexion.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nro_recinto", numeroRecinto);
                    
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

        public int actualizar_recinto(int numeroRecinto, decimal tarifa, string ubicacion, int id_tipo_recinto)
        {
            try
            {
                using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarRecinto", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nro_recinto", numeroRecinto);
                        cmd.Parameters.AddWithValue("@tarifa_hora", tarifa);
                        cmd.Parameters.AddWithValue("@ubicacion_recinto", ubicacion);
                        cmd.Parameters.AddWithValue("@id_tipo_recinto", id_tipo_recinto);

                        
                        cmd.ExecuteNonQuery();
                    }
                    conexion.Close();
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
