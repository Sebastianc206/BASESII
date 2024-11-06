using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace CINEBD.Model
{
    public class DBCONTE
    {
        private string connectionString;
        

        public DBCONTE()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CINEBD.Properties.Settings.CINEBDConnectionString"].ConnectionString;
        }

        public void EstablecerContextoSesionUsuario(SqlConnection connection)
        {
            if (!string.IsNullOrEmpty(Model.SesionContext.CurrentUser))
            {
                string query = "EXEC sp_set_session_context @key = N'Usuario', @value = @userName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userName", Model.SesionContext.CurrentUser);
                    command.ExecuteNonQuery();
                }
            }
        }


        //PROCEDIMIENTO VERIFICAR USUARIO
        public string VerificarUsuario(string nombre, string contraseña, out string rol)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    EstablecerContextoSesionUsuario(connection);


                    SqlCommand command = new SqlCommand("VerificaUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    // Parámetro de salida para el rol
                    SqlParameter rolParam = new SqlParameter("@Rol", SqlDbType.VarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(rolParam);

                    // Parámetro de salida para el mensaje de error
                    SqlParameter mensajeErrorParam = new SqlParameter("@mensajeError", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(mensajeErrorParam);

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();

                    // Obtener los valores de salida
                    rol = rolParam.Value == DBNull.Value ? null : rolParam.Value.ToString();
                    string mensajeError = mensajeErrorParam.Value.ToString();

                    return mensajeError;
                }
                catch (Exception ex)
                {
                    // Captura errores generales no relacionados con SQL Server
                    rol = null;
                    return $"Mensaje de error: {ex.Message}";
                }
            }
        }

        //PROCEDIMIENTO OBTENER ASIENTOS POR SALA

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

        //PROCEDIMIENTO CREAR PERLICULAS
        public string CrearPelicula(string nombre, string clasificacion, int duracion, string descripcion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    EstablecerContextoSesionUsuario(connection);

                    SqlCommand command = new SqlCommand("sp_CrearPelicula", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@clasificacion", clasificacion);
                    command.Parameters.AddWithValue("@duracion", duracion);
                    command.Parameters.AddWithValue("@descripcion", descripcion);

                    // Parámetro de salida para el mensaje de error
                    SqlParameter mensajeErrorParam = new SqlParameter("@mensajeError", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(mensajeErrorParam);

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();

                    // Obtener el mensaje de error del parámetro de salida
                    string mensajeError = mensajeErrorParam.Value.ToString();

                    return mensajeError;
                }
                catch (Exception ex)
                {
                    // Captura errores generales no relacionados con SQL Server
                    return $"Mensaje de error: {ex.Message}";
                }
            }
    }

        //ASIGNAR SESIONES
        public string CrearSesion(DateTime fechaInicio, int idSala, int idPelicula)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    EstablecerContextoSesionUsuario(connection);

                    SqlCommand command = new SqlCommand("sp_CrearSesion", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@idSala", idSala);
                    command.Parameters.AddWithValue("@idPelicula", idPelicula);

                    // Parámetro de salida para el mensaje de error
                    SqlParameter mensajeErrorParam = new SqlParameter("@mensajeError", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(mensajeErrorParam);

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();

                    // Obtener el mensaje de error del parámetro de salida
                    string mensajeError = mensajeErrorParam.Value.ToString();

                    return mensajeError;
                }
                catch (Exception ex)
                {
                    // Captura errores generales no relacionados con SQL Server
                    return $"Mensaje de error: {ex.Message}";
                }
            }
        }

        public string AnularTransaccion(int idTransaccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    EstablecerContextoSesionUsuario(connection);

                    // Crear el comando para ejecutar el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("sp_AnularTransaccion", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar el parámetro de entrada
                        command.Parameters.AddWithValue("@idTransaccion", idTransaccion);

                        // Agregar el parámetro de salida
                        SqlParameter mensajeErrorParam = new SqlParameter("@mensajeError", SqlDbType.NVarChar, -1);
                        mensajeErrorParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(mensajeErrorParam);

                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();

                        // Obtener el mensaje de error (o confirmación)
                        string mensajeError = mensajeErrorParam.Value.ToString();
                        return mensajeError;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    return $"Error al anular la transacción: {ex.Message}";
                }
            }
        }

        public DataTable ObtenerAsignaciones(int idTransaccion)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_ObtenerAsignaciones", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idTransaccion", idTransaccion);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // Método para obtener sesiones por película y sala mediante el procedimiento almacenado
        public DataTable ObtenerSesiones(int idPelicula, int idSala)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_ObtenerSesionPorPeliculaYSala", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPelicula", idPelicula);
                    command.Parameters.AddWithValue("@idSala", idSala);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // Método para desactivar sesión mediante el procedimiento almacenado
        public string DesactivarSesion(int idSesion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    EstablecerContextoSesionUsuario(connection);

                    SqlCommand command = new SqlCommand("sp_desactivarSesion", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    command.Parameters.AddWithValue("@idSesion", idSesion);

                    // Parámetro de salida para el mensaje de error
                    SqlParameter mensajeErrorParam = new SqlParameter("@mensajeError", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(mensajeErrorParam);

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();

                    // Obtener el mensaje de error del parámetro de salida
                    string mensajeError = mensajeErrorParam.Value.ToString();

                    return mensajeError;
                }
                catch (Exception ex)
                {
                    // Captura errores generales no relacionados con SQL Server
                    return $"Mensaje de error: {ex.Message}";
                }
            }
        }

        // Método para realizar la venta de boletos mediante el procedimiento almacenado
        public string VentaBoletos(int idSesion, string nombreUsuario, int cantAsientos, int idTipoAsignacion, string asientosTipoManual = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    EstablecerContextoSesionUsuario(connection);

                    SqlCommand command = new SqlCommand("sp_VentaBoletos", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    command.Parameters.AddWithValue("@idSesion", idSesion);
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@cantAsientos", cantAsientos);
                    command.Parameters.AddWithValue("@idTipoAsignacion", idTipoAsignacion);
                    if (!string.IsNullOrEmpty(asientosTipoManual))
                    {
                        command.Parameters.AddWithValue("@asientosTipoManual", asientosTipoManual);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@asientosTipoManual", DBNull.Value);
                    }

                    // Parámetro de salida para el mensaje de error
                    SqlParameter mensajeErrorParam = new SqlParameter("@mensajeError", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(mensajeErrorParam);

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();

                    // Obtener el mensaje de error del parámetro de salida
                    string mensajeError = mensajeErrorParam.Value.ToString();

                    return mensajeError;
                }
                catch (Exception ex)
                {
                    // Captura errores generales no relacionados con SQL Server
                    return $"Mensaje de error: {ex.Message}";
                }
            }
        }

        public DataTable ObtenerAsientosPorSesionYTransaccion(int idSesion, int idTransaccion)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_ObtenerAsientosPorSesionYTransaccion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idSesion", idSesion);
                    command.Parameters.AddWithValue("@idTransaccion", idTransaccion);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;      
    }


    }
}
