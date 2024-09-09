using Entity;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiSenatiSecuela.Data
{

    public class AlumnoData
    {
        private readonly IConfiguration _configuration;
        public AlumnoData(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Alumno> ListarAlumnos()
        {
            List<Alumno> oRetorno = new List<Alumno>();
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:strSql"]))
                {
                    SqlCommand cmd = new SqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "consultaAlumno";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Alumno oEntidad = new Alumno();

                            oEntidad.Id = (reader["id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["id"]);
                            oEntidad.Nombre = (reader["nombre"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["nombre"]);
                            oEntidad.Apellido = (reader["apellido"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["apellido"]);
                            oEntidad.Nacimiento = (reader["nacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["nacimiento"]));
                            oEntidad.IdGradoInstruccion= (reader["idGradoInstruccion"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["idGradoInstruccion"]);
                            oEntidad.Enabled= (reader["enabled"] == DBNull.Value) ? false : Convert.ToBoolean(reader["enabled"]);
                            oRetorno.Add(oEntidad);

                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                oRetorno = new List<Alumno>();
                // Opción alternativa: Imprimir información adicional en la consola
                Console.WriteLine("Se produjo un error al acceder a la base de datos:");
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine($"Pila de llamadas: {ex.StackTrace}");
            }
            return oRetorno;
        }
        public int CrearAlumno(AlumnoResponse alumno)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:strSql"]))
                {
                    using (SqlCommand cmd = new SqlCommand("CrearAlumno", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        cmd.Parameters.Add(new SqlParameter("@Nombre", alumno.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@Apellido", alumno.Apellido));
                        cmd.Parameters.Add(new SqlParameter("@Nacimiento", (object)alumno.Nacimiento ?? DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IdGradoInstruccion", alumno.IdGradoInstruccion));
                        cmd.Parameters.Add(new SqlParameter("@Enabled", alumno.Enabled));

                        // Añadir un parámetro de salida si deseas obtener el Id del nuevo registro
                        SqlParameter outputIdParam = new SqlParameter("@NewId", SqlDbType.Int);
                        outputIdParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputIdParam);

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        // Obtener el Id del nuevo registro
                        int newId = (int)outputIdParam.Value;
                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                // Opción alternativa: Imprimir información adicional en la consola
                Console.WriteLine("Se produjo un error al acceder a la base de datos:");
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine($"Pila de llamadas: {ex.StackTrace}");

                // Re-lanzar la excepción para que pueda ser manejada en un nivel superior
                throw new ApplicationException("Error al ejecutar el procedimiento almacenado.", ex);
            }
        }

        public bool ActualizarAlumno(AlumnoResponse alumno)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:strSql"]))
                {
                    using (SqlCommand cmd = new SqlCommand("ActualizarAlumno", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        cmd.Parameters.Add(new SqlParameter("@Id", alumno.Id));
                        cmd.Parameters.Add(new SqlParameter("@Nombre", alumno.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@Apellido", alumno.Apellido));
                        cmd.Parameters.Add(new SqlParameter("@Nacimiento", (object)alumno.Nacimiento ?? DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IdGradoInstruccion", alumno.IdGradoInstruccion));
                        cmd.Parameters.Add(new SqlParameter("@Enabled", alumno.Enabled));

                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        cn.Close();

                        // Retornar true si se actualizó al menos una fila
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Opción alternativa: Imprimir información adicional en la consola
                Console.WriteLine("Se produjo un error al acceder a la base de datos:");
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine($"Pila de llamadas: {ex.StackTrace}");

                // Re-lanzar la excepción para que pueda ser manejada en un nivel superior
                throw new ApplicationException("Error al ejecutar el procedimiento almacenado.", ex);
            }
        }


        public bool EliminarAlumno(int id)
        {
            bool oRetorno = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:strSql"]))
                {
                    SqlCommand cmd = new SqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"[deleteAlumno]";

                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    cmd.ExecuteNonQuery();
                    oRetorno = true;
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine($"Pila de llamadas: {ex.StackTrace}");
            }
            return oRetorno;
        }
    }
}
