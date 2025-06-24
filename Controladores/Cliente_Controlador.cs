using Modelos;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Controladores
{
    public class Cliente_Controlador
    {
        //llamada a procedimiento almacenado para agregar un cliente
        public int agregar_cliente(int dni, string nombre, string apellido, string telefono)
        {
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {

                using (SqlCommand comando = new SqlCommand("sp_InsertarCliente", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@dni_cliente", dni);
                    comando.Parameters.AddWithValue("@nombre_cliente", nombre);
                    comando.Parameters.AddWithValue("@apellido_cliente", apellido);
                    comando.Parameters.AddWithValue("@telefono_cliente", telefono);

                    conexion.Open();

                    int resultado = comando.ExecuteNonQuery();
                    conexion.Close();

                    return resultado;
                }
            }
        }
        //llamada al procedimiento almacenado para listar todos los clientes, incluyendo clientes inactivos
        public List<Cliente> listar_clientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("sp_ListarClientes", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.id_cliente = (int)reader["id_cliente"];
                            cliente.dni_cliente = (int)reader["dni_cliente"];
                            cliente.nombre_cliente = reader["nombre_cliente"].ToString();
                            cliente.apellido_cliente = reader["apellido_cliente"].ToString();
                            cliente.telefono_cliente = reader["telefono_cliente"].ToString();
                            cliente.estado_cliente = (bool)reader["estado_cliente"];
                            clientes.Add(cliente);
                        }
                    }
                }
                conexion.Close();
            }

            return clientes;
        }
        //llamada al procedimiento almacenado para modificar un cliente
        public int modificar_cliente(Cliente cliente)
        {
            int resultado;
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand("sp_ModificarCliente", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                comando.Parameters.AddWithValue("@dni_cliente", cliente.dni_cliente);
                comando.Parameters.AddWithValue("@nombre_cliente", cliente.nombre_cliente);
                comando.Parameters.AddWithValue("@apellido_cliente", cliente.apellido_cliente);
                comando.Parameters.AddWithValue("@telefono_cliente", cliente.telefono_cliente);
                comando.Parameters.AddWithValue("@estado_cliente", cliente.estado_cliente);
                conexion.Open();
                resultado = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return resultado;
        }
        //llamada al procedimiento almacenado para listar solo los clientes activos
        public List<Cliente> ListarClientesActivos()
        {
            List<Cliente> lista = new List<Cliente>();

            using (var conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarClientesActivos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cliente
                        {
                            id_cliente = (int)reader["id_cliente"],
                            dni_cliente = (int)reader["dni_cliente"],
                            nombre_cliente = reader["nombre_cliente"].ToString(),
                            apellido_cliente = reader["apellido_cliente"].ToString(),
                            telefono_cliente = reader["telefono_cliente"].ToString(),
                            estado_cliente = (bool)reader["estado_cliente"]
                        });
                    }
                }
            }

            return lista;
        }
        //llamada al procedimiento almacenado para dar de baja logica a un cliente mediante su id
        public void DarBajaCliente(int id)
        {
            using (var conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_BajaLogicaCliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cliente", id);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //llamada al procedimiento almacenado para dar de alta logica a un cliente mediante su id
        public void DarAltaCliente(int id)
        {
            using (var conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_AltaLogicaCliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cliente", id);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
