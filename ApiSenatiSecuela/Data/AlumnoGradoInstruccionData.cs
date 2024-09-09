using Entity;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiSenatiSecuela.Data
{
    public class AlumnoGradoInstruccionData
    {
        private readonly IConfiguration _configuration;
        public AlumnoGradoInstruccionData(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<AlumnoDetalle> GetAlumnosDetalle()
        {
            List<AlumnoDetalle> oRetorno = new List<AlumnoDetalle>();
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:strSql"]))
                {
                    using (SqlCommand cmd = new SqlCommand("get_gradoInstruccion_alumno_all", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AlumnoDetalle oEntidad = new AlumnoDetalle
                                {
                                    IdAlumno = reader.IsDBNull(reader.GetOrdinal("IdAlumno"))? 0 : reader.GetInt32(reader.GetOrdinal("IdAlumno")),
                                    Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre"))? string.Empty: reader.GetString(reader.GetOrdinal("Nombre")),
                                    Apellido = reader.IsDBNull(reader.GetOrdinal("Apellido"))? string.Empty: reader.GetString(reader.GetOrdinal("Apellido")),
                                    AlumnoActivo = reader.IsDBNull(reader.GetOrdinal("AlumnoActivo"))? false: reader.GetBoolean(reader.GetOrdinal("AlumnoActivo")),
                                    IdGradoInstruccion = reader.IsDBNull(reader.GetOrdinal("IdGradoInstruccion"))? 0 : reader.GetInt32(reader.GetOrdinal("IdGradoInstruccion")),
                                    GradoInstruccion = reader.IsDBNull(reader.GetOrdinal("GradoInstruccion")) ? string.Empty : reader.GetString(reader.GetOrdinal("GradoInstruccion"))
                                };

                                oRetorno.Add(oEntidad);
                            }
                        }

                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al acceder a la base de datos:");
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine($"Pila de llamadas: {ex.StackTrace}");
            }

            return oRetorno;
        }
        public List<GradoInstruccionAlumnos> GetIdGradoInstruccionAlumno(int id)
        {
            List<GradoInstruccionAlumnos> oRetorno = new List<GradoInstruccionAlumnos>();

            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:strSql"]))
                {
                    using (SqlCommand cmd = new SqlCommand("get_gradoInstruccion_alumno_byId", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        cn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GradoInstruccionAlumnos oEntidad = new GradoInstruccionAlumnos
                                {
                                    GradoInstruccion = reader.GetInt32(reader.GetOrdinal("GradoInstruccion")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                    IdAlumno = reader.GetInt32(reader.GetOrdinal("IdAlumno")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                                    AlumnoActivo = reader.GetBoolean(reader.GetOrdinal("AlumnoActivo"))
                                };

                                oRetorno.Add(oEntidad);
                            }
                        }
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al acceder a la base de datos:");
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine($"Pila de llamadas: {ex.StackTrace}");
                throw new ApplicationException("Error al ejecutar el procedimiento almacenado.", ex);
            }
            return oRetorno;
        }
    }
}
