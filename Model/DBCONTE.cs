using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CINEBD.Model
{
    public class DBCONTE
    {
        private string connectionString;

        public DBCONTE()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CINEBD.Properties.Settings.CINEBDConnectionString"].ConnectionString;
        }

        public (int, string) VerificarUsuario(string nombre, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_VerificaUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);

                        // Parámetro de salida para el rol
                        SqlParameter rolParam = new SqlParameter("@Rol", SqlDbType.VarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(rolParam);

                        // Parámetro de retorno para el resultado
                        SqlParameter returnParam = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParam.Direction = ParameterDirection.ReturnValue;

                        // Ejecutar el procedimiento
                        command.ExecuteNonQuery();

                        // Obtener el valor de retorno
                        int resultado = (int)command.Parameters["@ReturnVal"].Value;
                        string rol = (string)command.Parameters["@Rol"].Value;

                        return (resultado, rol);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción
                    Console.WriteLine("Error: " + ex.Message);
                    return (-99, null); // Código de error especial
                }
            }
        }

        public DataTable ObtenerAsientosPorSala(int idSala, int idSesion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_ObtenerAsientosDisponibles", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetro de entrada para el ID_Sala
                        command.Parameters.AddWithValue("@ID_Sala", idSala);
                        command.Parameters.AddWithValue ("@ID_Sesion", idSesion);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable asientosDisponibles = new DataTable();
                        adapter.Fill(asientosDisponibles);

                        // Verificar si se están llenando los datos
                        if (asientosDisponibles.Rows.Count > 0)
                        {
                            Console.WriteLine("Datos cargados correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron datos.");
                        }

                        return asientosDisponibles;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción
                    Console.WriteLine("Error: " + ex.Message);
                    return null; // Retornar null en caso de error
                }
            }
        }
    }
}
