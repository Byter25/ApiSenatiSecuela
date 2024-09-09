using ApiSenatiSecuela.Data;
using Entity;

namespace ApiSenatiSecuela.Bussines
{
    public class AlumnoBussines
    {
        private readonly IConfiguration _configuration;
        public AlumnoBussines(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Alumno> ConsultarAlumno() {
            List<Alumno> oRetorno = new List<Alumno>();
            oRetorno = new AlumnoData(_configuration).ListarAlumnos();
            return oRetorno;
        }
        public bool EliminarAlumno(int IdAlumno)
        {
            bool oRetorno = true;
            oRetorno = new AlumnoData(_configuration).EliminarAlumno(IdAlumno);
            return oRetorno;
        }
    }
}
