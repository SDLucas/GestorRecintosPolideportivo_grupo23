using Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Controladores
{
    public class Pago_Controlador
    {
        //llamada al procedimiento almacenado para registrar un pago
        public int registrar_pago(int id_reserva, int id_usuario, int id_medio, float monto)
        {
            int resultado;
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarPago", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@id_medio", id_medio);
                cmd.Parameters.AddWithValue("@monto", monto);
                conexion.Open();
                resultado = cmd.ExecuteNonQuery();
                conexion.Close();
            }
            return resultado;
        }
        //llamada al procedimiento almacenado para listar todos los pagos
        public List<Pago> listar_pagos()
        {
            List<Pago> pagos = new List<Pago>();

            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ListarPagos", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pagos.Add(new Pago
                        {
                            id_pago = (int)reader["id_pago"],
                            id_reserva = (int)reader["id_reserva"],
                            nombre_medio = reader["nombre_medio"].ToString(),
                            nombre_usuario = reader["Nombre_Usuario"].ToString(),
                            apellido_usuario = reader["Apellido_Usuario"].ToString(),
                            monto_pago = Convert.ToSingle(reader["monto_pago"]),
                            fecha_pago = Convert.ToDateTime(reader["fecha_pago"]),
                            nombre_cliente = reader["nombre_cliente"].ToString(),
                            apellido_cliente = reader["apellido_cliente"].ToString(),
                        });
                    }
                }
                conexion.Close();
            }

            return pagos;
        }

    }
}
