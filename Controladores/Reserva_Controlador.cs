using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Controladores
{
    public class Reserva_Controlador
    {
        public int agregar_reserva(DateTime fecha, int id_cliente, int nro_recinto, int id_usuario, int hora)
        {
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_InsertarReserva", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@fecha_reserva", fecha);
                    comando.Parameters.AddWithValue("@id_cliente", id_cliente);
                    comando.Parameters.AddWithValue("@nro_recinto", nro_recinto);
                    comando.Parameters.AddWithValue("@id_usuario", id_usuario);
                    comando.Parameters.AddWithValue("@hora_reserva", hora);
                    comando.Parameters.AddWithValue("@monto_reserva", Recinto_Controlador.obtener_recinto_por_numero(nro_recinto).tarifa_recinto );

                    conexion.Open();

                    int resultado = comando.ExecuteNonQuery();
                    conexion.Close();

                    return resultado;
                }

            }
        }

        public List<Reserva> listar_reservas()
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("sp_ListarReservas", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reserva reserva = new Reserva();
                            reserva.id_reserva = (int)reader["id_reserva"];
                            reserva.fecha_reserva = Convert.ToDateTime(reader["fecha_reserva"]);
                            reserva.hora_reserva = (int)reader["hora_reserva"];
                            reserva.monto_reserva = (float)(double)reader["monto_reserva"];
                            reserva.pagado = (bool)reader["pagado"];
                            reserva.nro_recinto = (int)reader["nro_recinto"];
                            reserva.id_cliente = (int)reader["id_cliente"];
                            reserva.id_usuario = (int)reader["id_usuario"];
                            reserva.nombre_cliente = reader["nombre_cliente"].ToString();
                            reserva.apellido_cliente = reader["apellido_cliente"].ToString();
                            reserva.nombre_usuario = reader["nombre_usuario"].ToString();
                            reserva.apellido_usuario = reader["apellido_usuario"].ToString();
                            reserva.estado = (bool)reader["estado"];

                            reservas.Add(reserva);
                        }
                    }
                }
                conexion.Close();
            }

            return reservas;
        }
        public List<int> ObtenerHorasReservadas(int nro_recinto, DateTime fecha)
        {
            List<int> horas = new List<int>();

            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("sp_HorasReservadas", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nro_recinto", nro_recinto);
                    comando.Parameters.AddWithValue("@fecha_reserva", fecha.Date);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            horas.Add((int)reader["hora_reserva"]);
                        }
                    }
                }
                conexion.Close();
            }

            return horas;
        }

        public int cancelar_reserva(int id_reserva)
        {
            int resultado;
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_CancelarReserva", conexion))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                conexion.Open();
                resultado = cmd.ExecuteNonQuery();
                conexion.Close();
                return resultado;
            }
        }

        public int actualizar_reserva(int id_reserva, DateTime fecha, int hora, int id_cliente, int nro_recinto)
        {
            int resultado;
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ActualizarReserva", conexion))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                cmd.Parameters.AddWithValue("@nro_recinto", nro_recinto);
                conexion.Open();
                resultado = cmd.ExecuteNonQuery();
                conexion.Close();
                return resultado;
            }
            
        }

        public Reserva obtener_reserva_por_id(int id_reserva)
        {
            Reserva reserva = null;
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("SELECT r.*, c.nombre_cliente, c.apellido_cliente, rec.tarifa_hora " +
                                                   "FROM Reserva r " +
                                                   "INNER JOIN Cliente c ON r.id_cliente = c.id_cliente " +
                                                   "INNER JOIN Recinto rec ON r.nro_recinto = rec.nro_recinto " +
                                                   "WHERE r.id_reserva = @id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", id_reserva);
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        reserva = new Reserva
                        {
                            id_reserva = (int)reader["id_reserva"],
                            fecha_reserva = Convert.ToDateTime(reader["fecha_reserva"]),
                            hora_reserva = (int)reader["hora_reserva"],
                            id_cliente = (int)reader["id_cliente"],
                            nro_recinto = (int)reader["nro_recinto"],
                            id_usuario = (int)reader["id_usuario"],
                            nombre_cliente = reader["nombre_cliente"].ToString(),
                            apellido_cliente = reader["apellido_cliente"].ToString(),
                            pagado = (bool)reader["pagado"],
                            monto_reserva = (float)(double)reader["monto_reserva"]
                        };
                    }
                }
            }

            return reserva;
        }


        public List<Reserva> listar_reservas_no_pagadas()
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ListarReservasNoPagadas", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservas.Add(new Reserva
                        {
                            id_reserva = (int)reader["id_reserva"],
                            fecha_reserva = Convert.ToDateTime(reader["fecha_reserva"]),
                            hora_reserva = (int)reader["hora_reserva"],
                            id_cliente = (int)reader["id_cliente"],
                            nro_recinto = (int)reader["nro_recinto"],
                            id_usuario = (int)reader["id_usuario"],
                            nombre_cliente = reader["nombre_cliente"].ToString(),
                            apellido_cliente = reader["apellido_cliente"].ToString(),
                            monto_reserva = (float)reader["monto_reserva"]
                        });
                    }
                }
                conexion.Close();
            }

            return reservas;
        }

        public bool existe_reserva_en_horario(DateTime fecha, int hora, int nro_recinto, int id_reserva_a_excluir)
        {
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ExisteReservaEnHorario", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@nro_recinto", nro_recinto);
                cmd.Parameters.AddWithValue("@id_excluir", id_reserva_a_excluir);
                conexion.Open();
                bool resultado;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    resultado = reader.HasRows;
                }
                conexion.Close();
                return resultado;
            }
        }
    }
}
