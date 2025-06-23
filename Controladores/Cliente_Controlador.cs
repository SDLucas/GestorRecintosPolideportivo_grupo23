using Modelos;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Controladores
{
    public class Cliente_Controlador
    {
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

                            clientes.Add(cliente);
                        }
                    }
                }
                conexion.Close();
            }

            return clientes;
        }

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

                conexion.Open();
                resultado = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return resultado;
        }

    }
}
